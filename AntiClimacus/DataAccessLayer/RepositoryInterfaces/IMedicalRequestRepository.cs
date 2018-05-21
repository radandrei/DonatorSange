using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IMedicalRequestRepository : IBaseRepository<Request>
    {
        int GetQuantityByBloodComponentTypeId(int componentId, int unitId);
        void Donate(int requestId, int distributionQuantity);
    }
}
