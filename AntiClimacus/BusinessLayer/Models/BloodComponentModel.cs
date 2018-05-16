using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class BloodComponentModel
    {

        public BloodComponentModel(BloodComponent blood)
        {

            Id = blood.Id;
            Name = blood.Name;
        }

        public BloodComponentModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

}