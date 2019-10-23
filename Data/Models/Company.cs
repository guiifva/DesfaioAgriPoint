using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

    }
}