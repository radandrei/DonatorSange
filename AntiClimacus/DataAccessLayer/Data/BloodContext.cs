using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Data
{
    public class BloodContext : DbContext
    {
        public BloodContext( DbContextOptions<BloodContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DonorData> DonorData { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<BloodComponent> BloodComponents { get; set; }
        public DbSet<BloodComponentType> BloodComponentTypes { get; set; }
        public DbSet<Request> Requests{ get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<UnitStatus> UnitStatuses { get; set; }
        public DbSet<BloodUnit> BloodUnits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Donor>().ToTable("Donor");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<BloodType>().ToTable("BloodType");
            modelBuilder.Entity<BloodComponent>().ToTable("BloodComponent");
            modelBuilder.Entity<BloodComponentType>().ToTable("BloodComponentType");
            modelBuilder.Entity<Request>().ToTable("Request");
            modelBuilder.Entity<RequestStatus>().ToTable("RequestStatus");
            modelBuilder.Entity<UnitStatus>().ToTable("UnitStatus");
            modelBuilder.Entity<BloodUnit>().ToTable("BloodUnit");
        }
    }
}
