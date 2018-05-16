using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly BloodContext context;

        public StatusRepository(BloodContext context)
        {
            this.context = context;
        }


        public Status AddOrUpdate(Status entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Status> GetAll()
        {
            return context.Statuses.ToList();
        }

        public Status GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
