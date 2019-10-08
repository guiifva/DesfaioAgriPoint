using Data.Models;
using ViewModel.BaseEntity;

namespace ViewModel.Order
{
    public class OrderViewModel : BaseEntityViewModel
    {
        public long UserId { get; set; }
        public double Total { get; set; }
        public string CreditCardNumber { get; set; }
        public int ValidDay { get; set; }
        public int ValidMonth { get; set; }
        public int CVV { get; set; }
    }
}
