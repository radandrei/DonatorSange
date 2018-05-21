using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BloodContext context;
        public AddressRepository(BloodContext context)
        {
            this.context = context;
        }
        public Address AddOrUpdate(Address entity)
        {
            if(entity.Id == 0)
            {
                //add address
                context.Addresses.Add(entity);
                context.SaveChanges();
                return entity;
            }
            else
            {
                //update address
                var address = context.Addresses.SingleOrDefault(add => add.Id == entity.Id);
                if (address == null)
                    return null;
                address.Number = entity.Number;
                address.City = entity.City;
                address.Country = entity.Country;
                address.County = entity.County;
                address.Street = entity.Street;
                context.Addresses.Update(address);
                context.SaveChanges();
                return address;
            }
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Address GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
