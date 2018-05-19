using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IBloodComponentRepository :IBaseRepository<BloodComponent>
    {
        List<BloodComponentType> GetAllTypes();
        void SubmitDonations(List<BloodDonation> donations);
    }
}
