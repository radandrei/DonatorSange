using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiClimacus.Models
{
    public class DonorBloodDonation
    {
        public int DonorId { get; set; }
        public List<BloodComponentQuantity> BloodComponents { get; set; }
        public bool Diseases { get; set; }

        public DonorBloodDonation()
        {

        }
    }
}
