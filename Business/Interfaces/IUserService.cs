using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ViewModel.Login;
using ViewModel.User;

namespace Business.Interfaces
{
    public interface IUserService 
    {
        Task<IdentityUser> InsertUserAsync(RegisterUserViewModel model);
        Task<IList<UserViewModel>> ListUsersAsync();
        Task<RegisterUserViewModel> UpdateAsync(RegisterUserViewModel model);
        Task<bool> DeleteAsync(string id);
        Task<UserViewModel> GetAsync(string id);
        Task<UserViewModel> GetByEmailAsync(string email);
    }
}
