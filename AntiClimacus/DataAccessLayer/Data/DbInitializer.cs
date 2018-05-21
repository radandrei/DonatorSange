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

            var statuses = new List<Status>()
            {
                new Status()
                {
                    Name="Registered"
                },
                new Status()
                {
                    Name="Taking blood"
                },
                new Status()
                {
                    Name="Preparing blood"
                },
                new Status()
                {
                    Name="Testing blood"
                },
                new Status()
                {
                    Name="Distributing blood"
                },
                new Status()
                {
                    Name="Rejected"
                }
            };

            _context.Statuses.AddRange(statuses);

            _context.BloodBanks.Add(new BloodBank());

            _context.SaveChanges();

            _context.MedicalUnits.Add(new MedicalUnit()
            {
                MedicalUnitTypeId = 1,
                AddressId = 1,
                BloodBankId = 1
            });

            _context.SaveChanges();

            _context.Users.Add(new User()
            {
                Username = "cipri",
                Password = "$KCOA$V1$10000$bRyC0Ll5o+5iHbKMDkgR1Dfqj73bu6RTRUz3viH234lBxGn5",
                FirstName = "Ciprian",
                LastName = "Pintilei",
                MedicalUnitId = 1,
                RoleId = 3
            });

            _context.Users.Add(new User()
            {
                Username = "roxana",
                Password = "$KCOA$V1$10000$bRyC0Ll5o+5iHbKMDkgR1Dfqj73bu6RTRUz3viH234lBxGn5",
                FirstName = "Rocsana",
                LastName = "Pam Pam",
                MedicalUnitId = 1,
                RoleId = 1
            });

            _context.Users.Add(new User()
            {
                Username = "dragos",
                Password = "$KCOA$V1$10000$bRyC0Ll5o+5iHbKMDkgR1Dfqj73bu6RTRUz3viH234lBxGn5",
                FirstName = "Dragos",
                LastName = "Onet",
                MedicalUnitId = 1,
                RoleId = 2
            });

            _context.RequestStatuses.AddRange(
                new List<RequestStatus>()
                {
                    new RequestStatus()
                    {
                        Name="Preparing"
                    },
                    new RequestStatus()
                    {
                        Name="Complete"
                    }
                });

            _context.SaveChanges();

            _context.Genders.Add(new Gender()
            {
                Name = "Male"
            });

            _context.Genders.Add(new Gender()
            {
                Name = "Female"
            });

            _context.SaveChanges();

            //_context.Donors.Add(new Donor()
            //{
            //    AddressId = 1,
            //    Email = "chip@chip.com",
            //    Phone = "0744005002",
            //    GenderId = 1,
            //    UserId = 1
            //});

            _context.Donors.Add(new Donor()
            {
                AddressId = 1,
                Email = "roxi@pam.com",
                Phone = "0744005002",
                GenderId = 2,
                UserId = 2
            });

            _context.SaveChanges();

            _context.DonationRequests.Add(new DonationRequest()
            {
                Active = true,
                Date = new DateTime(2018, 05, 16),
                DonorId = 1,
                StatusId = 1
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
                BloodPressure = 150,
                Birthdate = new DateTime(1997, 1, 14),
                Diseases = false,
                FeminineProblems = false,
                Heartbeat = 90,
                Interventions = false,
                JunkFood = false,
                OnDrugs = false
            });

            var bloodComponents = new List<BloodComponent>() {
                new BloodComponent()
                {
                    Name="Trombocyte",
                    Lifetime=5
                },
                new BloodComponent()
                {
                    Name="Red blood cell",
                    Lifetime=42
                },
                new BloodComponent()
                {
                    Name="Plasma",
                    Lifetime=150
                }
            };

            var bloodTypes = new List<BloodType>()
            {
                new BloodType()
                {
                    Name="A"
                },
                new BloodType()
                {
                    Name="B"
                },
                new BloodType()
                {
                    Name="AB"
                },
                new BloodType()
                {
                    Name="O"
                }
            };

            _context.BloodComponents.AddRange(bloodComponents);
            _context.BloodTypes.AddRange(bloodTypes);

            _context.SaveChanges();

            var bloodComponentTypes = new List<BloodComponentType>();

            for (int i = 1; i <= bloodComponents.Count; i++)
            {
                for (int j = 1; j <= bloodTypes.Count; j++)
                {
                    bloodComponentTypes.Add(new BloodComponentType()
                    {
                        BloodComponentId = i,
                        BloodTypeId = j
                    });
                }
            }

            _context.AddRange(bloodComponentTypes);

            _context.SaveChanges();

        }

    }
}
