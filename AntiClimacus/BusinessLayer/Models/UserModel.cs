
//using DataAccessLayer.Entities;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public RoleModel Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MedicalUnitModel MedicalUnit { get; set; }

        public UserModel()
        {

        }

        public UserModel(User user, bool withUnit = false)
        {
            if (user != null)
            {
                Id = user.Id;
                Username = user.Username;
                FirstName = user.FirstName;
                LastName = user.LastName;
                if (user.Role != null)
                    Role = new RoleModel(user.Role);
                if (withUnit)
                {
                    MedicalUnit = new MedicalUnitModel(user.MedicalUnit);
                }
            }
        }
    }
}