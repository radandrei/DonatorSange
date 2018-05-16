using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class UnitStatusModel
    {
        public UnitStatusModel(UnitStatus unit)
        {

            Id = unit.Id;
            Name = unit.Name;
        }

        public UnitStatusModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

