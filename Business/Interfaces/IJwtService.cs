using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IJwtService
    {
        Task<string> JWTGenerator(string email);
    }
}
