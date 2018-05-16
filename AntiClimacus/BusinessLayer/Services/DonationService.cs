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
        private readonly IStatusService statusService;
        public DonationService(IDonorRepository donorRepository, IStatusService statusService)
        {
            this.donorRepository = donorRepository;
            this.statusService = statusService;
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
    }
}
