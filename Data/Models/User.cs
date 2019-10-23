using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Data.Models
{
    public class User : IdentityUser
    {

        public long? CompanyId { get; set; }
        public long? AddressId { get; set; }

        [JsonIgnore]
        public virtual Company Company { get; set; }
        [JsonIgnore]
        public virtual Address Address { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Order { get; set; }

    }
}
