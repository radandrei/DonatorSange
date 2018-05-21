using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int QuantityDonated { get; set; }
        public int BloodComponentTypeId { get; set; }
        public int Priority { get; set; }
        public int MedicalUnitId { get; set; }
        public int RequestStatusId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public BloodComponentType BloodComponentType { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
