using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Services.OperationsForServices
{
    public class JwtUtils : IJwtUtils
    {
        public readonly AppSettings appSettings;
        public JwtUtils(IOptions<AppSettings> appSettings) {
            this.appSettings = appSettings.Value;

        }
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var appPrivateKey = Encoding.ASCII.GetBytes(this.appSettings.JwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(appPrivateKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Guid ValidateJwtToken(string token)
        {
            Console.WriteLine(token);
            if (token==null)
            {
                return Guid.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var appPrivateKey = Encoding.ASCII.GetBytes(this.appSettings.JwtSecret);
            Console.WriteLine(this.appSettings.JwtSecret);

            var tokenValidationParameters = new TokenValidationParameters()
            { 
                ValidateIssuerSigningKey= false,
                IssuerSigningKey = new SymmetricSecurityKey(appPrivateKey),
                ValidateIssuer= false,
                ValidateAudience= false,
               ClockSkew = TimeSpan.Zero,
            };

            try
            {
                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = new Guid(jwtToken.Claims.FirstOrDefault(x => x.Type == "id").Value);
                return userId;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return Guid.Empty;
            }

        }
    }
}
