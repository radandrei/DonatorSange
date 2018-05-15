using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        public ICollection<Donor> Users{ get; set; }
    }
}