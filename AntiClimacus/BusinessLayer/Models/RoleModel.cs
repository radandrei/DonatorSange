using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class RoleModel
    {
        public RoleModel(Role role)
        {
            ID = role.ID;
            Name = role.Name;
        }

        public RoleModel()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
