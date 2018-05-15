using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class RequestModel
    {
        public int ID { get; set; }
        public AddressModel AdressId { get; set; }
        public BloodComponentTypeModel BloodComponentTypeId { get; set; }
        public int Priority { get; set; }
        public int Quantity { get; set; }
        public RequestStatusModel RequestStatusId { get; set; }

        public RequestModel(Request req)
        {
            ID = req.ID;
            AdressId = new AddressModel(req.AdressId);
            BloodComponentTypeId = new BloodComponentTypeModel(req.BloodComponentTypeId);

            Priority = req.Priority;
            Quantity = req.Quantity;
            RequestStatusId = new RequestStatusModel(req.RequestStatusId);

        }
    }
}
