using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class DonorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel AdressId { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DonorDataModel DonorData { get; set; }

        public DonorModel(Donor donor)
        {
            Id = donor.Id;
            FirstName = donor.FirstName;
            LastName = donor.LastName;
            AdressId = new AddressModel(donor.Address);
            Gender = donor.Gender;
            Birthdate = donor.Birthdate;
            Phone = donor.Phone;
            Email = donor.Email;
            Gender = donor.Gender;
            DonorData = new DonorDataModel(donor.DonorData);
        }
    }
}
