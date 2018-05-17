using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class BloodComponentTypeModel
    {
        public int Id { get; set; }
        public BloodTypeModel BloodType { get; set; }
        public BloodComponentModel BloodComponent { get; set; }

        public BloodComponentTypeModel (BloodComponentType blood)
        {
            Id = blood.Id;
            BloodType = new BloodTypeModel(blood.BloodType);
            BloodComponent = new BloodComponentModel(blood.BloodComponent);
        }
    }
}
