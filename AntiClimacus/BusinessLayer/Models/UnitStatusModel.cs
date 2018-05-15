using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class UnitStatusModel
    {
        public UnitStatusModel(UnitStatus unit)
        {

            ID = unit.ID;
            Name = unit.Name;
        }

        public UnitStatusModel()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
}
