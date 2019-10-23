using Business.Interfaces;
using Data;
using Data.Repository.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ViewModel.Login;

namespace Business.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            IUserRepository userRepository,
                            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IdentityUser> RegisterUserAsync(RegisterUserViewModel model)
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
    }
}
