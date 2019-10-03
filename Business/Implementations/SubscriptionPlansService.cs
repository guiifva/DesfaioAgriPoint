using Business.Interfaces;
using Data;
using Data.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Implementations
{
    public class SubscriptionPlansService : ServiceCrud<SubscriptionPlans>, ISubscriptionPlansService
    {
        public SubscriptionPlansService(ISubscriptionPlansRepository repository) 
            : base(repository)
        {
        }
    }
}
