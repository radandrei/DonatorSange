using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class DonorData
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime Birthdate { get; set; }
        public int Weight { get; set; }
        public int BloodTypeId { get; set; }
        public int Heartbeat { get; set; }
        public int BloodPressure { get; set; }
        public bool Interventions { get; set; }
        public bool FeminineProblems { get; set; }
        public bool JunkFood { get; set; }
        public bool OnDrugs { get; set; }
        public bool Diseases { get; set; }

        public BloodType BloodType { get; set; }
        public Donor Donor { get; set; }
    }
}
