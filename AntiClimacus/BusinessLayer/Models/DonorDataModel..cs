using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class DonorDataModel
    {
        public int Id { get; set; }
        public BloodTypeModel BloodTypeId { get; set; }
        public DateTime Birthdate { get; set; }
        public DonorModel Donor { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public int Weight { get; set; }

        public DonorDataModel(DonorData donor)
        {
            Id = donor.Id;
            BloodTypeId = new BloodTypeModel(donor.BloodType);
            Birthdate = donor.Birthdate;
            Donor = new DonorModel(donor.Donor);
            Email = donor.Email;
            Gender = donor.Gender;
            Phone = donor.Phone;
            Weight = donor.Weight;

            

        }
    }
}
