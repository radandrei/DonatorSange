using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IMedicalRequestService
    {
        List<RequestModel> GetAllRequests();
        RequestModel GetRequestById(int id);
        int GetBloodComponentQuantity(int componentId, int unitdId);
        void DonateBlood(RequestModel request, int distributionQuantity);
    }
}
