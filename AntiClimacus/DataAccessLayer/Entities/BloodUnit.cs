using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class BloodUnit
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int StatusId { get; set; }

        public UnitStatus Status { get; set; }
    }
}
