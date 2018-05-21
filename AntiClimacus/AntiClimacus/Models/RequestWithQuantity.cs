using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiClimacus.Models
{
    public class RequestWithQuantity
    {
        public RequestModel Request { get; set; }
        public int DistributionQuantity { get; set; }

        public RequestWithQuantity()
        {
        }
    }
}
