using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Utils.Helper;
using ViewModel.Order;

namespace Business.Implementations
{
    public class DailyJobs : IDailyJobs
    {
        private IOrdersService _ordersService;
        private ISubscriptionPlansService _subscriptionPlansService;

        public DailyJobs(IOrdersService ordersService,
                         ISubscriptionPlansService subscriptionPlansService)
        {
            _ordersService = ordersService;
            _subscriptionPlansService = subscriptionPlansService;
        }

        public async Task RunDaily()
        {
            try
            {
                var ordersExpiring = await _ordersService.AllAsync(x => x.PlanRenewalDate.Date == DateTimeHelper.BrazilNow.Date);

                if (ordersExpiring.Any())
                {
                    foreach (var order in ordersExpiring)
                    {
                        var subscriptionPlan = await _subscriptionPlansService.GetAsync(order.SubscriptionPlanId);

                        var newOrder = new Order
                        {
                            CreditCardId = order.CreditCardId,
                            SubscriptionPlanId = order.SubscriptionPlanId,
                            PurchaseDay = DateTimeHelper.BrazilNow,
                            PlanRenewalDate = DateTimeHelper.BrazilNow.AddMonths(subscriptionPlan.PlanMonths),
                            Total = subscriptionPlan.Value,
                            UserId = order.UserId
                        };


                        var result = await _ordersService.InsertModelAsync(newOrder);

                        Console.WriteLine(result + "/r");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
