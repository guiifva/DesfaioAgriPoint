using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class SubscriptionPlansRepository : Repository<SubscriptionPlans>, ISubscriptionPlansRepository
    {
        public SubscriptionPlansRepository(ApplicationContext context) 
            : base(context)
        {
        }
    }
}
