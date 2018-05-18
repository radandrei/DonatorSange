using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class BloodComponentQuantityModel
    {
        public BloodComponentModel BloodComponent { get; set; }
        public int Quantity { get; set; }

        public BloodComponentQuantityModel()
        {

        }
    }
}
