using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data.Models
{
    public class Address : BaseEntity
    {
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int PlaceNumber { get; set; }
        public string Complement { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
