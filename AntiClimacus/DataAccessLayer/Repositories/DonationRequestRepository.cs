using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class DonationRequestRepository : IDonationRequestRepository
    {
        private readonly BloodContext context;

        public DonationRequestRepository(BloodContext context)
        {
            this.context = context;
        }

        public DonationRequest AddOrUpdate(DonationRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<DonationRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public DonationRequest GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
