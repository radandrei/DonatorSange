using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodContext context;

        public DonorRepository(BloodContext context)
        {
            this.context = context;
        }

        public Donor AddOrUpdate(Donor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Donor> GetAll(int medicalUnitId)
        {
            return context.Donors.Where(donor => donor.User.MedicalUnitId == medicalUnitId).Include(d=>d.Gender).Include(d=>d.Address).Include(x => x.DonorData.BloodType).Include(d => d.User.Role).Include(d => d.DonationRequests).AsNoTracking().ToList();
        }

        public List<Donor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Donor GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
