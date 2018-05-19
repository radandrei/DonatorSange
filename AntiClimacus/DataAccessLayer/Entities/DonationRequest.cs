using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class DonationRequest
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string RecipientName { get; set; }
        public DateTime Date { get; set; }
        public int StatusId { get; set; }
        public bool Active { get; set; }

        public ICollection<BloodDonation> BloodDonations { get; set; }
        public Status Status { get; set; }
        public Donor Donor { get; set; }
    }
}
