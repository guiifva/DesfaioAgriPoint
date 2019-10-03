using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Orders : BaseEntity
    {
        public long UserId { get; set; }
        public double Total { get; set; }
        public string CreditCardNumber { get; set; }
        public virtual User User { get; set; }
    }
}
