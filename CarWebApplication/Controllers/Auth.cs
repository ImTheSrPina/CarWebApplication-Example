using Microsoft.AspNetCore.Mvc;

using CarWebApplication.Models;
using CarWebApplication.Services;

namespace CarWebApplication.Controllers
{
    public class AuthController : Controller
    {

        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("[controller]/Login")]
        public ActionResult<string> Login([FromBody] Login loginData)
        {
            User? user = UsersDataBase.Login(loginData);

            if (user == null)
            {
                return Unauthorized();
            }

            string JwtToken = _jwtService.GenerateSecurityToken(user.Id, user.Name, user.SecondName, user.Role);

            return Ok(JwtToken);
        }
    }
}
