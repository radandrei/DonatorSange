using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class RequestModel
    {
        public int Id { get; set; }
        public AddressModel Address { get; set; }
        public BloodComponentTypeModel BloodComponentType { get; set; }
        public int Priority { get; set; }
        public int Quantity { get; set; }
        public RequestStatusModel RequestStatus { get; set; }

        public RequestModel(Request req)
        {
            Id = req.Id;
            BloodComponentType = new BloodComponentTypeModel(req.BloodComponentType);

            Priority = req.Priority;
            Quantity = req.Quantity;
            RequestStatus = new RequestStatusModel(req.RequestStatus);

        }
    }
}
