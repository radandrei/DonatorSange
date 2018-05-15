using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class DonorData
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public int Weight { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public int BloodTypeId { get; set; }

        public BloodType BloodType { get; set; }
        public Donor Donor { get; set; }
    }
}
