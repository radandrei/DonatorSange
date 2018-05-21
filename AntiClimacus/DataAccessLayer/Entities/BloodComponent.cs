using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class BloodComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Lifetime { get; set; }
    }
}
