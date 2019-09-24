using Business.Interfaces;
using Data;
using Data.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Implementations
{
    public class UserService : ServiceCrud<User>, IUserService
    {
        public UserService(IUserRepository repository) 
            : base(repository)
        {
        }
    }
}
