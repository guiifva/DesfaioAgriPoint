using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Order;
using ViewModel.SubscriptionsPlans;

namespace Business.Interfaces
{
    public interface IOrdersService : IServiceCrud<Order, OrderViewModel>
    {
        Task<OrderViewModel> InsertWithPlanAsync(OrderViewModel model, SubscriptionsPlansViewModel plan);
        Task<OrderViewModel> InsertModelAsync(Order model);
    }
}
