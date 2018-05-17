using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class BloodBank
    {
        public int Id { get; set; }
        public int BloodComponentTypeId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        public int DonationId { get; set; }

        public BloodComponentType BloodComponentType { get; set; }
        public Donation Donation { get; set; }
    }
}
