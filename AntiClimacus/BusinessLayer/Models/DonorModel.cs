using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Models
{
    public class DonorModel
    {
        public int Id { get; set; }
        public AddressModel Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public GenderModel Gender { get; set; }
        public DonorDataModel DonorData { get; set; }
        public DonationRequestModel DonationRequest { get; set; }
        public UserModel User { get; set; }

        public DonorModel()
        {

        }
        public DonorModel(Donor donor)
        {
            Id = donor.Id;
            Address = new AddressModel(donor.Address);
            Gender = new GenderModel();
            Gender.Id = donor.Gender.Id;
            Gender.Name = donor.Gender.Name;
            Phone = donor.Phone;
            Email = donor.Email;
            DonorData = donor.DonorData == null ? null : new DonorDataModel(donor.DonorData);
            User = new UserModel(donor.User);
            var donationRequest = donor.DonationRequests.FirstOrDefault(d => d.Active == true);
            DonationRequest = donationRequest == null ? new DonationRequestModel() : new DonationRequestModel(donationRequest);
        }
    }
}
