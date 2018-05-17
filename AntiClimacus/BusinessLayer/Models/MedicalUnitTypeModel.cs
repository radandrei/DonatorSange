using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class MedicalUnitTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MedicalUnitTypeModel(MedicalUnitType medicalUnitType)
        {
            Id = medicalUnitType.Id;
            Name = medicalUnitType.Name;
        }
    }
}