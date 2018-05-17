using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IDonationRequestService
    {
        void UpdateStatusOfDonorRequest(int donorId, int statusId);
    }
}
