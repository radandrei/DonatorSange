using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class MedicalUnitModel
    {

        public int Id { get; set; }
        public AddressModel Address { get; set; }
        public MedicalUnitTypeModel MedicalUnitType { get; set; }

        public MedicalUnitModel(MedicalUnit medicalUnit)
        {
            Id = medicalUnit.Id;
            Address = new AddressModel(medicalUnit.Address);
            MedicalUnitType = new MedicalUnitTypeModel(medicalUnit.MedicalUnitType);
        }
    }
}