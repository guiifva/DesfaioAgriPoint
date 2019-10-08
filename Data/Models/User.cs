using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long AdressId { get; set; }
        public long? CompanyId { get; set; }   

        public virtual Company Company { get; set; }
        public virtual Address Address { get; set; }
        public virtual Order Order { get; set; }

    }
}
