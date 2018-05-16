
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
            public AddressModel AdressId { get; set; }
            public string Password { get; set; }
            public UserModel()
            {

            }

            public UserModel(User user)
            {
                Id = user.Id;
                Username = user.Username;
                Password = user.Password;
                Role = new RoleModel(user.Role);   
            }
        }
    }