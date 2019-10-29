using Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Business.Implementations
{
    public class JwtService : IJwtService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public JwtService(UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<string> JWTGenerator(string email)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(email);

                var identityClaims = new ClaimsIdentity();
                identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Id)
                    }),
                    Issuer = _appSettings.Issuer,
                    Audience = _appSettings.Audience,
                    Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
