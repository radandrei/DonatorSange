using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class DonationRequest
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string RecipientName { get; set; }

        public Donor Donor { get; set; }
    }
}
