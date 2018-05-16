using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class BloodUnitModel
    {
        public BloodUnitModel(BloodUnit unit)
        {

            Id = unit.Id;
            DateAdded = unit.DateAdded;
            StatusId = new UnitStatusModel(unit.Status);
        }

        public BloodUnitModel()
        {

        }
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public UnitStatusModel StatusId { get; set; }
    }
}
