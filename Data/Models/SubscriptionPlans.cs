using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class SubscriptionPlans : BaseEntity
    {
        public string PlanName { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }
}
