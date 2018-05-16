using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Donor
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }

        public DonorData DonorData { get; set; }
        public Address Address { get; set; }
        public ICollection<DonationRequest> DonationRequests { get; set; }
    }
}
