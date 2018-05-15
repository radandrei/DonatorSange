using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class BloodTypeModel
    {

        public BloodTypeModel(BloodType blood)
        {

            ID = blood.ID;
            Name = blood.Name;
        }

        public BloodTypeModel()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
    }

}
