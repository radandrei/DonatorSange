using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IUserService
    {
        UserModel GetUserById(int id);
        UserModel CreateUser(string username, string password);
        UserModel GetUserByUsernameAndPassword(string username, string password);
    }
}
