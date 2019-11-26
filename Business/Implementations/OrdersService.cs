using Business.Interfaces;
using Data;
using Data.Repository.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Utils;
using Utils.Helper;
using ViewModel.Order;
using ViewModel.SubscriptionsPlans;
using ViewModel.Report;

namespace Business.Implementations
{
    public class OrdersService : ServiceCrud<Order, OrderViewModel>, IOrdersService
    {
        public OrdersService(IOrdersRepository repository,
                                IMapper mapper)
            : base(repository, mapper)
        {
        }

        public async Task<OrderViewModel> InsertWithPlanAsync(OrderViewModel model, SubscriptionsPlansViewModel plan)
        {

            var entity = _mapper.Map<Order>(model);

            //adicionando Timestamp do dia da compra e do dia da renovação e valor da compra
            entity = PreSave(entity, plan);

            await _repository.InsertAsync(entity);

            return _mapper.Map<OrderViewModel>(entity);
        }

        private Order PreSave(Order model, SubscriptionsPlansViewModel plan)
        {
            model.CreditCard.CreditCardNumber = model.CreditCard.CreditCardNumber.Substring(12, 4);
            model.PurchaseDay = DateTimeHelper.BrazilNow;
            model.PlanRenewalDate = model.PurchaseDay.AddMonths(plan.PlanMonths);

            var listHolidaysBrazil = Holidayshelper.GetHolidaysByCurrentYear().ToList();
            if (listHolidaysBrazil.Contains(model.PlanRenewalDate))
                model.PlanRenewalDate = DateTimeHelper.diaUtil(model.PlanRenewalDate.AddDays(1));
                

            model.Total = plan.Value;

            return model;
        }

        //validação se um cliente tem mais de um pedido
        public async Task<OrderViewModel> InsertModelAsync(Order model)
        {
            await _repository.InsertAsync(model);

            return _mapper.Map<OrderViewModel>(model);
        }

        public async Task<IList<RenewalReportViewModel>> ListRenewalReport()
        {
            var list = _repository.All()
                            .Include(x => x.User)
                            .Include(x => x.SubscriptionPlan)
                            .Select(x => new RenewalReportViewModel()
                            {
                                OrderId = x.Id,
                                UserName = x.User.UserName,
                                Email = x.User.Email,
                                Plan = x.SubscriptionPlan.PlanName,
                                PlanValue = x.SubscriptionPlan.Value,
                                PlanRenewalDate = x.PlanRenewalDate.ToString("dd-MM-yyyy")
                            });

            return await list.ToListAsync();
        }

        public async Task<IList<OrderReportViewModel>> ListOrdersReport()
        {
            var list = _repository.All()
                .Include(x => x.User)
                .Include(x => x.SubscriptionPlan)
                .Select(x => new OrderReportViewModel()
                {
                    OrderId = x.Id,
                    UserName = x.User.UserName,
                    Email = x.User.Email,
                    Plan = x.SubscriptionPlan.PlanName,
                    PlanValue = x.SubscriptionPlan.Value,
                    PurchaseDay = x.PurchaseDay.ToString("dd-MM-yyyy")
                });

            return await list.ToListAsync();
        }
    }
}
