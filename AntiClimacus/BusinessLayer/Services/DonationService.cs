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
            var list = donorRepository.GetAll(medicalUnitId).ToList();

            if (list.Count > 0)
            {
                var newList = list.Select(d => new DonorModel(d)).ToList();

                foreach (var donor in newList)
                {
                    donor.DonationRequest.Status.Name = statusList.FirstOrDefault(x => x.Id == donor.DonationRequest.Status.Id).Name;
                }

                return newList;
            }

            return new List<DonorModel>();
        }

        public void SubmitDonationFromDonor(int donorId, List<BloodComponentQuantityModel> bloodComponents, bool diseases)
        {
            var donorData = donorDataRepository.GetByDonorId(donorId);
            var bloodComponentTypes = bloodComponentRepository.GetAllTypes();
            donorData.Donor.DonationRequests.FirstOrDefault(x => x.Active == true).StatusId = 4;
            var requestId = donorData.Donor.DonationRequests.FirstOrDefault(x => x.Active == true).Id;
            donorData.Donor.HasCondition =diseases ;
            var bankId = donorData.Donor.User.MedicalUnit.BloodBankId;
            var today = DateTime.Today;

            List<BloodDonation> donations = new List<BloodDonation>();


            foreach (var component in bloodComponents)
            {
                var componentType = bloodComponentTypes.FirstOrDefault(x => x.BloodComponentId == component.BloodComponent.Id && x.BloodTypeId == donorData.BloodTypeId);

                donations.Add(new BloodDonation()
                {
                    BloodBankId = bankId,
                    DateAdded = today,
                    DonationRequestId = requestId,
                    Quantity = component.Quantity,
                    BloodComponentTypeId = componentType.Id
                });
            }

            donorDataRepository.AddOrUpdate(donorData);
            bloodComponentRepository.SubmitDonations(donations);
        }

        public void SubmitDonorData(DonorDataModel model,int donorId)
        {
            var donorData = new DonorData()
            {
                Birthdate = model.Birthdate,
                BloodPressure = model.BloodPressure,
                BloodTypeId = model.BloodType.Id,
                DonorId = donorId,
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
