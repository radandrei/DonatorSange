using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class MedicalUnitModel
    {

        public int Id { get; set; }
        public AddressModel Address { get; set; }
        public MedicalUnitTypeModel MedicalUnitType { get; set; }

        public MedicalUnitModel()
        {

        }

        public MedicalUnitModel(MedicalUnit medicalUnit)
        {
            if (medicalUnit != null)
            {
                Id = medicalUnit.Id;
                Address = new AddressModel(medicalUnit.Address);

                if (medicalUnit.MedicalUnitType != null)
                    MedicalUnitType = new MedicalUnitTypeModel(medicalUnit.MedicalUnitType);
            }
        }
    }
}