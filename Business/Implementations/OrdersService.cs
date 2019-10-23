using Business.Interfaces;
using Data;
using Data.Repository.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ViewModel.Order;

namespace Business.Implementations
{
    public class OrdersService : ServiceCrud<Order, OrderViewModel>, IOrdersService
    {
        public OrdersService(IOrdersRepository repository,
                                IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
