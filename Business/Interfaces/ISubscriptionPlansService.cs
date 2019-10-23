using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SubscriptionsPlans;

namespace Business.Interfaces
{
    public interface ISubscriptionPlansService : IServiceCrud<SubscriptionPlans, SubscriptionsPlansViewModel>
    {
    }
}
