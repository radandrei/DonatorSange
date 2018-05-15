using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class RoleModel
    {
        public RoleModel(Role role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public RoleModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
