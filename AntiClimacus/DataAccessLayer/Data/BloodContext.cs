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
        public DbSet<Status> Statuses { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodTest> BloodTests { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<MedicalUnit> MedicalUnits { get; set; }
        public DbSet<MedicalUnitType> MedicalUnitTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }

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
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<DonationRequest>().ToTable("DonationRequest");
            modelBuilder.Entity<Donation>().ToTable("Donation");
            modelBuilder.Entity<BloodTest>().ToTable("BloodTest");
            modelBuilder.Entity<Condition>().ToTable("Condition");
            modelBuilder.Entity<MedicalUnit>().ToTable("MedicalUnit");
            modelBuilder.Entity<MedicalUnitType>().ToTable("MedicalUnitType");
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<BloodBank>().ToTable("BloodBank");

            modelBuilder.Entity<Donor>()
                .HasOne(d => d.User).WithOne(x => x.Donor).IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(d => d.User).WithMany(x => x.Requests).IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicalUnit>().
                HasOne(x => x.BloodBank).WithOne(b => b.MedicalUnit).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
