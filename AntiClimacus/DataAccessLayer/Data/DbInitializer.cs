using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Data
{
    public static class DbInitializer
    {

        public static void Initialize(BloodContext _context)
        {
            _context.Database.EnsureCreated();

            var roles = new Role[]
            {
            new Role{Name="Medic"},
            new Role{Name="Donor"},
            new Role{Name="Staff"},
            };
            foreach (Role s in roles)
            {
                _context.Roles.Add(s);
            }
            _context.SaveChanges();
        }

    }
}
