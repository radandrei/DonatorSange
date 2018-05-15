
//using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
    {
        public class UserModel
        {
            public int ID { get; set; }
            public string Username { get; set; }
            public RoleModel RoleId { get; set; }
            public AddressModel AdressId { get; set; }
            public string Password { get; set; }
            public UserModel()
            {

            }

            public UserModel(User user)
            {
                ID = user.ID;
                Username = user.Username;
                Password = user.Password;
                RoleId = new RoleModel(user.RoleId);
                
                AdressId = new AddressModel(user.AdressId);
            }
        }
    }