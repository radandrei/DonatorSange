using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Donor
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public int UserId { get; set; }
        public bool HasCondition { get; set; }

        public Gender Gender { get; set; }
        public User User { get; set; }
        public DonorData DonorData { get; set; }
        public Address Address { get; set; }
        public ICollection<DonationRequest> DonationRequests { get; set; }
    }
}
