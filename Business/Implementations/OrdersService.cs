using Business.Interfaces;
using Data;
using Data.Repository.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Utils.Helper;
using ViewModel.Order;
using ViewModel.SubscriptionsPlans;

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

            //adicionando Timestamp do dia da compra e do dia da renovação
            entity = PreSave(entity, plan);

            await _repository.InsertAsync(entity);

            return _mapper.Map<OrderViewModel>(entity);
        }

        private Order PreSave(Order model, SubscriptionsPlansViewModel plan)
        {
            model.PurchaseDay = DateTimeHelper.BrazilNow;
            model.PlanRenewalDate = model.PurchaseDay.AddMonths(plan.PlanMonths);

            return model;
        }

    }
}
