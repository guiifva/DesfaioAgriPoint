using Business.Interfaces;
using Data;
using Data.Repository.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ViewModel.SubscriptionsPlans;

namespace Business.Implementations
{
    public class SubscriptionPlansService : ServiceCrud<SubscriptionPlans, SubscriptionsPlansViewModel>, ISubscriptionPlansService
    {
        public SubscriptionPlansService(ISubscriptionPlansRepository repository,
                                        IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
