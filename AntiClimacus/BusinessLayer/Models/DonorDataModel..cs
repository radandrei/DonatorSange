using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class DonorDataModel
    {
        public int ID { get; set; }
        public BloodTypeModel BloodTypeId { get; set; }
        public DateTime Birthdate { get; set; }
        public DonorModel DonorId { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public int Weight { get; set; }

        public DonorDataModel(DonorData donor)
        {
            ID = donor.ID;
            BloodTypeId = new BloodTypeModel(donor.BloodTypeId);
            Birthdate = new DateTime(donor.Birthdate);
            DonorId = new DonorModel(donor.DonorId);
            Email = donor.Email;
            Gender = donor.Gender;
            Phone = donor.Phone;
            Weight = donor.Weight;

            

        }
    }
}
