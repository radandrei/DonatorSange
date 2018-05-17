using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Data
{
    public static class DbInitializer
    {

        public static void Initialize(BloodContext _context)
        {
            _context.Database.EnsureCreated();

            if (_context.Users.Any())
            {
                return;
            }

            var roles = new Role[]
            {
            new Role{Name="Donor"},
            new Role{Name="Medic"},
            new Role{Name="Staff"}
            };

            foreach (Role s in roles)
            {
                _context.Roles.Add(s);
            }

            _context.MedicalUnitTypes.Add(new MedicalUnitType()
            {
                Name = "Donation Center"
            });

            _context.SaveChanges();

            _context.Addresses.Add(new Address()
            {
                Country = "Romania",
                County = "Bucharest",
                City = "Bucharest",
                Street = "Vicovului",
                Number = 10
            });

            _context.SaveChanges();

            _context.MedicalUnits.Add(new MedicalUnit()
            {
                MedicalUnitTypeId = 1,
                AddressId = 1
            });

            _context.SaveChanges();

            _context.Users.Add(new User()
            {
                Username = "cipri",
                Password = "$KCOA$V1$10000$bRyC0Ll5o+5iHbKMDkgR1Dfqj73bu6RTRUz3viH234lBxGn5",
                FirstName = "Ciprian",
                LastName = "Pintilei",
                MedicalUnitId = 1,
                RoleId = 1
            });

            _context.SaveChanges();

            _context.Genders.Add(new Gender()
            {
                Name = "Male"
            });

            _context.SaveChanges();

            _context.Donors.Add(new Donor()
            {
                AddressId = 1,
                Birthdate = new DateTime(1990, 1, 1),
                Email = "chip@chip.com",
                Phone = "0744005002",
                GenderId = 1,
                UserId = 1
            });

            _context.SaveChanges();

            _context.Statuses.AddRange(new List<Status>()
            {
               new Status() {
                    Name = "Request registered"
               },
               new Status()
               {
                   Name="Blood taken"
               },
               new Status()
               {
                   Name="Blood tested"
               },
               new Status()
               {
                   Name="Blood Distributed"
               }
            });

            _context.SaveChanges();

            _context.DonationRequests.Add(new DonationRequest()
            {
                Active = true,
                Date = new DateTime(2018, 05, 16),
                DonorId = 1,
                StatusId=1
            });

            _context.DonationRequests.Add(new DonationRequest()
            {
                Active = false,
                Date = new DateTime(2018, 05, 16),
                DonorId = 1,
                StatusId = 1
            });

            _context.SaveChanges();


            _context.BloodTypes.Add(new BloodType()
            {
                Name = "A0"
            });

            _context.SaveChanges();

            _context.DonorData.Add(new DonorData()
            {
                DonorId = 1,
                Weight = 60,
                BloodTypeId = 1,
                BloodPressure=150,
                Diseases=false,
                FeminineProblems=false,
                Heartbeat=90,
                Interventions=false,
                JunkFood=false,
                OnDrugs=false
            });

            _context.SaveChanges();
        }

    }
}
