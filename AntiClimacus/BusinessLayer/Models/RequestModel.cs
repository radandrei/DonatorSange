using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public BloodComponentTypeModel BloodComponentType { get; set; }
        public int Priority { get; set; }
        public int Quantity { get; set; }
        public RequestStatusModel RequestStatus { get; set; }
        public UserModel User { get; set; }
        public MedicalUnitModel MedicalUnit { get; set; }

        public RequestModel()
        {

        }

        public RequestModel(Request req)
        {
            Id = req.Id;
            BloodComponentType = new BloodComponentTypeModel(req.BloodComponentType);
            Priority = req.Priority;
            Quantity = req.Quantity;
            RequestStatus = new RequestStatusModel(req.RequestStatus);
            User = new UserModel(req.User);
            MedicalUnit = new MedicalUnitModel(req.MedicalUnit);
        }
    }
}
