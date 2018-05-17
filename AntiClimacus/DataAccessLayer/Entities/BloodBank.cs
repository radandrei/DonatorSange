using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class BloodBank
    {
        public int Id { get; set; }

        public MedicalUnit MedicalUnit { get; set; }
        public ICollection<BloodDonation> BloodDonations { get; set; }
    }
}
