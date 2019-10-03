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
    public class OrdersService : ServiceCrud<Orders>, IOrdersService
    {
        public OrdersService(IOrdersRepository repository) 
            : base(repository)
        {
        }
    }
}
