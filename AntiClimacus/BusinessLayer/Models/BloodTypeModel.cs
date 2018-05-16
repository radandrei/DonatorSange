using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class BloodTypeModel
    {

        public BloodTypeModel(BloodType blood)
        {

            Id = blood.Id;
            Name = blood.Name;
        }

        public BloodTypeModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
