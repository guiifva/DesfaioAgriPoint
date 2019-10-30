using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using Newtonsoft.Json;

namespace Data.Models
{
    public class CreditCard : BaseEntity
    {
        public string CardholderName { get; set; }
        public string CreditCardNumber { get; set; }
        public string Valid { get; set; }
        public string CVV { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Order { get; set; }
    }
}
