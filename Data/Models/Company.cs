using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}