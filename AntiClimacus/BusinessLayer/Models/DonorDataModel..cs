using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class DonorDataModel
    {
        public int Id { get; set; }
        public BloodTypeModel BloodType { get; set; }
        public int Weight { get; set; }

        public DonorDataModel(DonorData donor)
        {
            Id = donor.Id;
            BloodType = new BloodTypeModel(donor.BloodType);
            Weight = donor.Weight;
        }
    }
}
