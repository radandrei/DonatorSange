using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class DonationCenter
    {
        public int Id { get; set; }

        public ICollection<User> Users { get; set; }
    }
}