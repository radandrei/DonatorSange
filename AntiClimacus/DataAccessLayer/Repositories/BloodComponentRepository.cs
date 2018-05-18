using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class BloodComponentRepository : IBloodComponentRepository
    {
        private readonly BloodContext context;

        public BloodComponentRepository(BloodContext bloodContext)
        {
            context = bloodContext;
        }

        public BloodComponent AddOrUpdate(BloodComponent entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<BloodComponent> GetAll()
        {
            return context.BloodComponents.ToList();
        }

        public List<BloodComponentType> GetAllTypes()
        {
            return context.BloodComponentTypes.ToList();
        }

        public BloodComponent GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void SubmitDonations(List<BloodDonation> donations)
        {
            foreach( var donation in donations)
            {
                context.BloodDonations.Add(donation);
            }

            context.SaveChanges();
        }
    }
}
