using BusinessLayer.Models;
using BusinessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonorRepository donorRepository;
        private readonly IBloodTypeRepository bloodTypeRepository;
        private readonly IStatusService statusService;
        private readonly IBloodComponentRepository bloodComponentRepository;
        private readonly IDonorDataRepository donorDataRepository;


        public DonationService(IDonorRepository donorRepository, 
            IStatusService statusService, 
            IBloodTypeRepository bloodTypeRepository, 
            IBloodComponentRepository bloodComponentRepository,
            IDonorDataRepository donorDataRepository)
        {
            this.donorRepository = donorRepository;
            this.statusService = statusService;
            this.bloodTypeRepository = bloodTypeRepository;
            this.bloodComponentRepository = bloodComponentRepository;
            this.donorDataRepository = donorDataRepository;
        }

        public List<BloodComponentModel> GetBloodComponents()
        {
            return bloodComponentRepository.GetAll().Select(x => new BloodComponentModel(x)).ToList();
        }

        public List<BloodTypeModel> GetBloodTypes()
        {
            return bloodTypeRepository.GetAll().Select(x => new BloodTypeModel(x)).ToList();
        }

        public List<DonorModel> GetDonors(int medicalUnitId)
        {
            List<StatusModel> statusList = statusService.GetAllStatuses();
            List<DonorModel> list = donorRepository.GetAll(medicalUnitId).Select(d => new DonorModel(d)).ToList();

            foreach(var donor in list)
            {
                donor.DonationRequest.Status.Name = statusList.FirstOrDefault(x => x.Id == donor.DonationRequest.Status.Id).Name;
            }

            return list;
        }

        public void SubmitDonorData(DonorDataModel model)
        {
            var donorData = new DonorData()
            {
                Birthdate = model.Birthdate,
                BloodPressure = model.BloodPressure,
                BloodTypeId = model.BloodType.Id,
                DonorId = model.Donor.Id,
                Diseases = model.Diseases,
                FeminineProblems = model.FeminineProblems,
                Heartbeat = model.Heartbeat,
                Interventions = model.Interventions,
                JunkFood = model.JunkFood,
                OnDrugs = model.JunkFood,
                Weight = model.Weight,
                Id = model.Id
            };

            donorDataRepository.AddOrUpdate(donorData);
        }
    }
}
