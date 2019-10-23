using System;
using Data.Models;
using ViewModel.BaseEntity;

namespace ViewModel.Order
{
    public class OrderViewModel : BaseEntityViewModel
    {
        public string UserId { get; set; }
        public double Total { get; set; }
        public long SubscriptionPlanId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
