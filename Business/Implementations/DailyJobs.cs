using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Utils;
using Utils.Helper;
using ViewModel.Order;

namespace Business.Implementations
{
    public class DailyJobs : IDailyJobs
    {
        private IOrdersService _ordersService;
        private ISubscriptionPlansService _subscriptionPlansService;
        private readonly ILogger _logger;


        public DailyJobs(IOrdersService ordersService,
                         ISubscriptionPlansService subscriptionPlansService,
                         ILogger<DailyJobs> logger)
        {
            _logger = logger;
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
                        _logger.LogWarning($"Renovando a assinatura com id: {order.Id}, do usuario: {order.UserId}, com o plano {order.SubscriptionPlanId}");

                        var subscriptionPlan = await _subscriptionPlansService.GetAsync(order.SubscriptionPlanId);

                        var renewalFutureDate =
                            DateTimeHelper.BrazilNow.AddMonths(subscriptionPlan.PlanMonths).AddDays(1);

                        var listHolidaysBrazil = Holidayshelper.GetHolidaysByCurrentYear().ToList();
                        if (listHolidaysBrazil.Contains(renewalFutureDate))
                            renewalFutureDate = DateTimeHelper.diaUtil(renewalFutureDate.AddDays(1));

                        var newOrder = new Order
                        {
                            CreditCardId = order.CreditCardId,
                            SubscriptionPlanId = order.SubscriptionPlanId,
                            PurchaseDay = DateTimeHelper.BrazilNow,
                            PlanRenewalDate = renewalFutureDate,
                            Total = subscriptionPlan.Value,
                            UserId = order.UserId
                        };


                        var result = await _ordersService.InsertModelAsync(newOrder);
                        _logger.LogWarning($"Assinatura com id: {result.Id}, do usuario: {result.UserId}, com o plano {result.SubscriptionPlanId}. Foi renovada com sucesso!");
                        Console.WriteLine(result + "/r");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning($"Não foi possivel renovar a assinatura, erro {e.Message}");

                Console.WriteLine(e.Message);
            }
        }
    }
}
