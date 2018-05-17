using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IDonationRequestRepository : IBaseRepository<DonationRequest>
    {
        DonationRequest GetDonationRequestByDonorId(int donorId);
        void UpdateStatus(DonationRequest donationRequest, int statusId);
    }
}
