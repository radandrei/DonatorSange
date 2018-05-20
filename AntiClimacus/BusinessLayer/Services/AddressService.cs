using BusinessLayer.Models;
using BusinessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public AddressModel AddOrUpdateAdress(AddressModel addressModel)
        {
            var address = new Address() {
                Id = addressModel.Id,
                City = addressModel.City,
                Country = addressModel.Country,
                County = addressModel.County,
                Number = addressModel.Number,
                Street = addressModel.Street
            };
            address = addressRepository.AddOrUpdate(address);
            return new AddressModel(address);
        }
    }
}
