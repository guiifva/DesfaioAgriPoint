using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ViewModel.Login;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<IdentityUser> RegisterUserAsync(RegisterUserViewModel model);
    }
}
