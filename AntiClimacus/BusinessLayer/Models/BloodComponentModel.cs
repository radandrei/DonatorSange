using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class BloodComponentModel
    {

        public BloodComponentModel(BloodComponent blood)
        {

            ID = blood.ID;
            Name = blood.Name;
        }

        public BloodComponentModel()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
    }

}