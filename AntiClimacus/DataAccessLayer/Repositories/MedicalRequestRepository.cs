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
    public class MedicalRequestRepository : IMedicalRequestRepository
    {
        private readonly BloodContext context;

        public MedicalRequestRepository(BloodContext context)
        {
            this.context = context;
        }

        public Request AddOrUpdate(Request entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetAll()
        {
            return context.Requests.Include(x => x.BloodComponentType.BloodComponent).Include(x => x.BloodComponentType.BloodType).Include(x => x.RequestStatus).Include(x => x.User).Include(x => x.MedicalUnit.Address).ToList();
        }

        public Request GetById(int Id)
        {
            return context.Requests.Where(x => x.Id == Id).Include(x => x.BloodComponentType.BloodComponent).Include(x => x.BloodComponentType.BloodType).Include(x => x.RequestStatus).Include(x => x.User).Include(x => x.MedicalUnit.Address).FirstOrDefault();

        }

        public int GetQuantityByBloodComponentTypeId(int componentId, int unitId)
        {
            var today = DateTime.Today;

            var das = context.BloodDonations.Where(x => x.BloodBank.MedicalUnit.Id == unitId && x.BloodComponentTypeId == componentId && ((today - x.DateAdded).Days <= x.BloodComponentType.BloodComponent.Lifetime)).Select(y => y.Quantity).Sum();

            return das;
        }

        public void Donate(int requestId, int quantityToDonate)
        {
            var request = context.Requests.FirstOrDefault(x => x.Id == requestId);
            var today = DateTime.Today;

            if (request != null)
            {
                var donations = context.BloodDonations.Where(x => x.BloodBank.MedicalUnit.Id == request.MedicalUnitId && x.BloodComponentTypeId == request.BloodComponentTypeId && ((today - x.DateAdded).Days <= x.BloodComponentType.BloodComponent.Lifetime)).ToList();

                foreach (var donation in donations)
                {
                    if (quantityToDonate > 0)
                    {
                        if (quantityToDonate > donation.Quantity)
                        {
                            request.QuantityDonated += donation.Quantity;
                            donation.Quantity = 0;
                            quantityToDonate = quantityToDonate - donation.Quantity;
                        }
                        else{
                            request.QuantityDonated += donation.Quantity - quantityToDonate;
                            donation.Quantity = donation.Quantity - quantityToDonate;
                            quantityToDonate = 0;
                        }
                        context.BloodDonations.Update(donation);
                    }
                }

                if (request.QuantityDonated == request.Quantity)
                {
                    request.RequestStatusId = 2;
                    context.Requests.Update(request);
                }

                context.SaveChanges();
            }
        }
    }
}
