﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class BloodTest
    {
        public int Id { get; set; }
        public int ConditionId { get; set; }
        public int DonationId { get; set; }
        public bool HasCondition  { get; set; }

        public Condition Condition { get; set; }
        public Donation Donation { get; set; }
    }
}
