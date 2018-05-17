using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class BloodTypeRepository : IBloodTypeRepository
    {
        private readonly BloodContext context;

        public BloodTypeRepository(BloodContext bloodContext)
        {
            context = bloodContext;
        }

        public BloodType AddOrUpdate(BloodType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<BloodType> GetAll()
        {
            return context.BloodTypes.ToList();
        }

        public BloodType GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
