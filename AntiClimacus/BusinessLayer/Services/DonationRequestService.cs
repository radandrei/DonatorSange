using BusinessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class DonationRequestService : IDonationRequestService
    {
        private readonly IDonationRequestRepository donationRequestRepository;

        public DonationRequestService(IDonationRequestRepository donationRequestRepository)
        {
            this.donationRequestRepository = donationRequestRepository;
        }

        public void UpdateStatusOfDonorRequest(int donorId, int statusId)
        {
            DonationRequest donationRequest= donationRequestRepository.GetDonationRequestByDonorId(donorId);
            donationRequestRepository.UpdateStatus(donationRequest, statusId);
        }
    }
}
