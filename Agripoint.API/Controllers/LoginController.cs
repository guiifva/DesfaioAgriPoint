using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Login;

namespace Agripoint.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(IJwtService jwtService,
                                SignInManager<IdentityUser> signInManager,
                                IUserService userService)
        {
            _signInManager = signInManager;
            _jwtService = jwtService;
            _userService = userService;
        }

        /// <summary>
        /// Rota para login no sistema
        /// </summary>
        /// <param name="model">LoginUserViewModel</param>
        /// <returns>Token para acesso ao sistema</returns>
        [HttpPost("SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(await _jwtService.JWTGenerator(model.Email));
            }

            return BadRequest("Usuário ou senha inválidos");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

            try
            {
                var result = await _userService.RegisterUserAsync(model);

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            





        }
    }
}