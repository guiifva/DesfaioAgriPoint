using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Order;

namespace Business.Interfaces
{
    public interface IOrdersService : IServiceCrud<Order, OrderViewModel>
    {
    }
}
