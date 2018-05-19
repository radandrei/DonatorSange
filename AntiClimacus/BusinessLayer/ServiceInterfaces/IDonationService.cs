using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Models;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IDonationService
    {
        List<DonorModel> GetDonors(int medicalUnitId);
        List<BloodComponentModel> GetBloodComponents();
        List<BloodTypeModel> GetBloodTypes();
        void SubmitDonorData(DonorDataModel model,int donorId);
        void SubmitDonationFromDonor(int donorId, List<BloodComponentQuantityModel> bloodComponenents, bool diseases);
    }
}
