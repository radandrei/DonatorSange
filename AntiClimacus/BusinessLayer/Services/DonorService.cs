using BusinessLayer.Models;
using BusinessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonationRequestRepository donationRequestRepository;
        private readonly IDonorRepository donorRepository;
        private readonly IAddressRepository addressRepository;
        public DonorService(IDonationRequestRepository donationRequestRepository, IDonorRepository donorRepository, IAddressRepository addressRepository)
        {
            this.donationRequestRepository = donationRequestRepository;
            this.donorRepository = donorRepository;
            this.addressRepository = addressRepository;
        }
        public void RegisterDonor(DonorModel model)
        {
            var addressModel = model.Address;
            var address = new Address()
            {
                Id = addressModel.Id,
                City = addressModel.City,
                Country = addressModel.Country,
                County = addressModel.County,
                Number = addressModel.Number,
                Street = addressModel.Street
            };
            var addressId = addressRepository.AddOrUpdate(address).Id;
            var donor = new Donor()
            {
                AddressId = addressId,
                Email = model.Email,
                GenderId = model.Gender.Id,
                Phone = model.Phone,
                UserId = model.User.Id
            };

            var donorId = donorRepository.AddOrUpdate(donor).Id;
            var donationRequest = new DonationRequest()
            {
                Active = true,
                Date = DateTime.Now,
                DonorId = donorId,
                RecipientName = model.DonationRequest.RecipientName,
                StatusId = model.DonationRequest.Status.Id
            };

            donationRequestRepository.AddOrUpdate(donationRequest);
        }
    }
}
