

using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace CarWebApplication.Services
{
    public class JwtService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _expirationTime; // Minutes
    
        public JwtService(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
            _expirationTime = configuration["Jwt:ExpirationTime"];
        }

        public string GenerateSecurityToken(int id, string name, string surname, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new List<Claim>
                {
                    new Claim("ID", id.ToString()),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Surname, surname),
                    new Claim(ClaimTypes.Role, role)
                },
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_expirationTime)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
