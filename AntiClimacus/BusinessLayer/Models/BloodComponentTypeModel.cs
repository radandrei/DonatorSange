using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class BloodComponentTypeModel
    {
        public int ID { get; set; }
        public BloodComponentModel BloodComponentId { get;set; }

        public BloodTypeModel BloodTypetId { get; set; }



        public BloodComponentTypeModel (BloodComponentType blood)
        {
            ID = blood.ID;
            BloodTypetId = new BloodTypeModel(blood.BloodTypetId);
            BloodComponentId = new BloodComponentTypeModel(blood.BloodComponentId);
       

        }
    }
}
