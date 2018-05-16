﻿using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class UserRepository : IUserRepository
    {
        private BloodContext context;

        public UserRepository(BloodContext context)
        {
            this.context = context;
        }

        public User AddOrUpdate(User user)
        {
            var newUser = new User();
            newUser = context.Users.Where(x => x.Username.ToLower().Equals(user.Username.ToLower())).FirstOrDefault();

            try
            {
                if (newUser != null)
                {
                    newUser.Username = user.Username;
                    newUser.Password = user.Password;
                    newUser.RoleId = user.RoleId;
                    context.Update(newUser);
                }
                else
                {
                    newUser = new User()
                    {
                        Username = user.Username,
                        Password = user.Password,
                        RoleId = user.RoleId
                    };
                    context.Add(newUser);
                }
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            context.SaveChanges();

            return GetById(newUser.Id);
        }

        public void Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAll()
        {
            return context.Users.Include(z => z.Role).AsNoTracking().ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Where(x => x.Id == id).Include(z => z.Role).Include(y => y.Donor).Include(a => a.Donor.DonorData)
                .AsNoTracking().FirstOrDefault();
        }

        public User GetByUsername(string username)
        {
            return context.Users.Where(x => x.Username.Equals(username)).Include(z => z.Role).AsNoTracking().FirstOrDefault();
        }
    }
}
