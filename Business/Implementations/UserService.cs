using Business.Interfaces;
using Data;
using Data.Repository.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CryptoHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ViewModel.Address;
using ViewModel.Company;
using ViewModel.Login;
using ViewModel.User;

namespace Business.Implementations
{
    public class UserService :  IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            IUserRepository repository,
                            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<IList<UserViewModel>> ListUsersAsync()
        {

            var list = _mapper.Map<IEnumerable<User>, IList<UserViewModel>>(await _userRepository.AllAsync());

            return list;
        }

        public async Task<IdentityUser> InsertUserAsync(RegisterUserViewModel model)
        {
            var user = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true,
                Address = _mapper.Map<Address>(model.AddressViewModel)
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                throw new Exception("Não foi possivel concluir o cadastro");

            await _signInManager.SignInAsync(user, false);

            var userCreated = await _userManager.FindByNameAsync(model.Email);

            return userCreated;
        }

        public async Task<RegisterUserViewModel> UpdateAsync(RegisterUserViewModel model)
        {
            var user = await _userRepository.FindAsync(model.Id);

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PasswordHash = Crypto.HashPassword(model.Password);
            user.Address = _mapper.Map<Address>(model.AddressViewModel);
            user.CompanyId = model.CompanyId;

            var result = await _userManager.UpdateAsync(user);

            //var user = new User()
            //{
            //    UserName = model.Email,
            //    Email = model.Email,
            //    EmailConfirmed = true,
            //    Address = _mapper.Map<Address>(model.AddressViewModel)
            //};
            try
            {

                await _userManager.UpdateAsync(user);
            }
            catch (Exception e)
            {
                throw e;
            }

            return _mapper.Map<RegisterUserViewModel>(user);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _userRepository.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            await _userRepository.DeleteAsync(entity);

            return true;
        }

        public async Task<UserViewModel> GetAsync(string id)
        {
            var entity = await _userRepository.FindAsync(id);
            return _mapper.Map<User, UserViewModel>(entity);
        }

        public async Task<UserViewModel> GetByEmailAsync(string email)
        {
            var entity = await _userRepository.FindByEmailAsync(email);
            return _mapper.Map<User, UserViewModel>(entity);
        }
    }
}
