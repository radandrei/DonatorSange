using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class DonorDataModel
    {
        public int Id { get; set; }
        public DateTime Birthdate { get; set; }
        public BloodTypeModel BloodType { get; set; }
        public int Weight { get; set; }
        public int Heartbeat { get; set; }
        public int BloodPressure { get; set; }
        public bool Interventions { get; set; }
        public bool FeminineProblems { get; set; }
        public bool JunkFood { get; set; }
        public bool OnDrugs { get; set; }
        public bool Diseases { get; set; }

        public DonorDataModel(DonorData donor)
        {
            Id = donor.Id;
            BloodType = new BloodTypeModel(donor.BloodType);
            Weight = donor.Weight;
            Heartbeat = donor.Heartbeat;
            BloodPressure = donor.BloodPressure;
            Interventions = donor.Interventions;
            FeminineProblems = donor.FeminineProblems;
            JunkFood = donor.JunkFood;
            OnDrugs = donor.OnDrugs;
            Diseases = donor.Diseases;
            Birthdate = donor.Birthdate;
        }
    }
}
