using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utils
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}