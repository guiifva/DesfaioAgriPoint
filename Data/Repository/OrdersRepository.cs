using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(ApplicationContext context) 
            : base(context)
        {
        }
    }
}
