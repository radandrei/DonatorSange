using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class GenderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GenderModel(Gender gender)
        {
            Id = gender.Id;
            Name = gender.Name;
        }
    }
}