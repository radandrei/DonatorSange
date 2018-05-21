using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IDonorService
    {
        void RegisterDonor(DonorModel model);
    }
}
