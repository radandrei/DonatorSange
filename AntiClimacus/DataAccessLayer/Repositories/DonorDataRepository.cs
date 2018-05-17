using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class DonorDataRepository : IDonorDataRepository
    {
        private readonly BloodContext context;

        public DonorDataRepository(BloodContext context)
        {
            this.context = context;
        }

        public DonorData AddOrUpdate(DonorData entity)
        {
            var oldData = context.DonorData.FirstOrDefault(x => x.Id == entity.Id);

            if (oldData != null)
            {
                oldData.Heartbeat = entity.Heartbeat;
                oldData.Interventions = entity.Interventions;
                oldData.JunkFood = entity.JunkFood;
                oldData.OnDrugs = entity.JunkFood;
                oldData.Weight = entity.Weight;
                oldData.Birthdate = entity.Birthdate;
                oldData.BloodPressure = entity.BloodPressure;
                oldData.Diseases = entity.Diseases;
                oldData.FeminineProblems = entity.FeminineProblems;

                context.Update(oldData);
            }
            else
            {
                oldData = new DonorData();
                oldData.Heartbeat = entity.Heartbeat;
                oldData.Interventions = entity.Interventions;
                oldData.JunkFood = entity.JunkFood;
                oldData.OnDrugs = entity.JunkFood;
                oldData.Weight = entity.Weight;
                oldData.Birthdate = entity.Birthdate;
                oldData.BloodPressure = entity.BloodPressure;
                oldData.Diseases = entity.Diseases;
                oldData.FeminineProblems = entity.FeminineProblems;
                oldData.DonorId = entity.DonorId;

                context.Add(oldData);
            }

            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<DonorData> GetAll()
        {
            throw new NotImplementedException();
        }

        public DonorData GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
