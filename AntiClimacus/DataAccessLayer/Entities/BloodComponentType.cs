using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class BloodComponentType
    {
        public int Id { get; set; }
        public int BloodTypeId { get; set; }
        public int BloodComponentId { get; set; }

        public BloodComponent BloodComponent { get; set; }
        public BloodType BloodType { get; set; }
    }
}
