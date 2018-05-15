using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class DonorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel AdressId { get; set; }




        public DonorModel(Donor donor)
        {
            Id = donor.Id;
            FirstName = donor.FirstName;
            LastName = donor.LastName;
            AdressId = new AddressModel(donor.Address);
        }
    }
}
