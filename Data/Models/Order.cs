using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Data.Models
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public double Total { get; set; }
        public long CreditCardId { get; set; }
        public long SubscriptionPlanId { get; set; }
        public DateTime PurchaseDay { get; set; }
        public DateTime PlanRenewalDate { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual CreditCard CreditCard { get; set; }
        [JsonIgnore]
        public virtual SubscriptionPlans SubscriptionPlan { get; set; }

    }
}
