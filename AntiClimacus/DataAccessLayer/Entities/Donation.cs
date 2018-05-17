using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Donation
    {
        public int Id { get; set; }
        public int DonationRequestId { get; set; }
        public DateTime Date { get; set; }
        public int BloodQuantity { get; set; }

        public DonationRequest DonationRequest { get; set; }
    }
}
