using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int MedicalUnitId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Role Role { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
        public Donor Donor { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
