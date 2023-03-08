using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using NextBus_API.Models.Entities;
using Microsoft.VisualBasic;

namespace NextBus_API.Configs
{
    public sealed class JwtAuthenticationManager
    {
        private JwtAuthenticationManager() { }
        private static JwtAuthenticationManager instance = null;
        public static JwtAuthenticationManager Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new JwtAuthenticationManager();
                }
                return instance;
            }
        }

        private static readonly IConfiguration _configuration;

        private JwtAuthResponse AuthenticateBusOwner(BusOwner busOwner)
        {
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(30);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, busOwner.BusOwnerCode)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new JwtAuthResponse
            {
                Token = jwt,
                ID = busOwner.BusOwnerCode,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
            };
        }
    }

    #region JwtAuthResponse
    public class JwtAuthResponse
    {
        public string Token { get; set; }

        public string ID { get; set; }

        public int ExpiresIn { get; set; }
    }
    #endregion
}
