using System;
using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class DonationRequestModel
    {
        public int Id { get; set; }
        public string RecipientName { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public StatusModel Status { get; set; }

        public DonationRequestModel(DonationRequest donationRequest)
        {
            Id = donationRequest.Id;
            RecipientName = donationRequest.RecipientName;
            Date = donationRequest.Date;
            Active = donationRequest.Active;
            Status = donationRequest.Status == null ? new StatusModel(donationRequest.StatusId) : new StatusModel(donationRequest.Status);
        }

        public DonationRequestModel()
        {
        }
    }
}