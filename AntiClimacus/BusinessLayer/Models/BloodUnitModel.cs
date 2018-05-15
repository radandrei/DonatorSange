using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class BloodUnitModel
    {
        public BloodUnitModel(BloodUnit unit)
        {

            ID = unit.ID;
            DateAdded = new DateTime(unit.DateAdded);
            StatusId = new UnitStatusModel(unit.StatusId);
        }

        public BloodUnitModel()
        {

        }
        public int ID { get; set; }
        public DateTime DateAdded { get; set; }
        public UnitStatusModel StatusId { get; set; }
    }
}
