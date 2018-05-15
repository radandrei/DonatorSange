using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class DonorModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel AdressId { get; set; }

       


        public DonorModel(Donor donor)
        {
            ID = donor.ID;
            FirstName = donor.FirstName;
            LastName = donor.LastName;
            AdressId = new AddressModel(donor.AdressId);
            

        }
    }
}
