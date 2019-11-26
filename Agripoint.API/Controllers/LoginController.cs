using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModel.Login;

namespace Agripoint.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(IJwtService jwtService,
                                SignInManager<IdentityUser> signInManager,
                                IUserService userService,
                                ILogger<LoginController> logger)
        {
            _signInManager = signInManager;
            _jwtService = jwtService;
            _userService = userService;
            _logger = logger;
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
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Usuario {model.Email} não logado, erros: {ModelState.Values.SelectMany(e => e.Errors)}");

                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                try
                {
                    _logger.LogWarning($"Usuario {model.Email} logado com sucesso");
                    return Ok(await _jwtService.JWTGenerator(model.Email));
                }
                catch (Exception e)
                {
                    _logger.LogWarning($"Usuario {model.Email} não logado, erros: {e.Message}");

                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }

            return BadRequest("Usuário ou senha inválidos");
        }

        /// <summary>
        /// Inserir o objeto na base de dados.
        /// </summary>
        /// <param name="model">Objeto para registro na base de dados</param>
        /// <returns>Objeto contendo os dados recém adicionados.</returns>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

            try
            {
                var result = await _userService.InsertUserAsync(model);
                _logger.LogWarning($"Usuario cadastradato com sucesso: {result}");
                return Ok(result);
            }
            catch(Exception e)
            {
                _logger.LogWarning($"Nao foi possivel registrar os usuarios, erros: {e.Message}");
                return BadRequest("Errors:" + e.Message);
            }
        }
    }
}