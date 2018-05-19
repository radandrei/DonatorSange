using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }

        public AddressModel()
        {

        }

        public AddressModel(Address address)
        {
            if (address != null)
            {
                Id = address.Id;
                City = address.City;
                Country = address.Country;
                County = address.County;
                Number = address.Number;
                Street = address.Street;
            }

        }
    }
}
