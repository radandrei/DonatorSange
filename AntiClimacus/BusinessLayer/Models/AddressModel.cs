using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AddressModel
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }

        public AddressModel(AddressModel address)
        {
            ID = address.ID;
            City = address.City;
            Country = address.Country;
            County = address.County;
            Number = address.Number;
            Street = address.Street;

        }
    }
}
