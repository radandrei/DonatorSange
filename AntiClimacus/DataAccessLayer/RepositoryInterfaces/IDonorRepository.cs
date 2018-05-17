using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IDonorRepository :IBaseRepository<Donor>
    {
        List<Donor> GetAll(int medicalUnitId);
    }
}
