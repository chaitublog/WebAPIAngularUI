using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustService.Models;
using Microsoft.Extensions.Options;
using CustService.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CustService.Services
{
    public class AdminService:IAdminService
    {
        private readonly CustomerDBContext _custDBContext;
        private readonly IOptions<AppSettings> _appSettings;

        public AdminService(CustomerDBContext _custDBContext, IOptions<AppSettings> _appSettings)
        {
            this._custDBContext = _custDBContext;
            this._appSettings = _appSettings;
        }

        public UserLogin Authenticate(string Username, string Password)
        {

            UserLogin loginUser = _custDBContext.UserLogin.SingleOrDefault(c => c.Username == Username && c.Password == Password);

            // return null if user not found
            if (loginUser == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, loginUser.Uid.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            loginUser.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            loginUser.Password = null;

            return loginUser;


        }
    }
}
