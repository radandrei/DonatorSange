using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class MedicalUnit
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int MedicalUnitTypeId { get; set; }

        public MedicalUnitType MedicalUnitType { get; set; }
        public Address Address { get; set; }
        public ICollection<User> Users { get; set; }
    }
}