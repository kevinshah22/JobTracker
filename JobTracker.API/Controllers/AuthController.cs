using JobTracker.Data.Models;
using JobTracker.Data.Repositories;
using JobTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobTracker.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JWTConfigModel _jwtConfigModel;
        public AuthController(IUserRepository userRepository, JWTConfigModel jwtConfigModel)
        {
            _userRepository = userRepository;
            _jwtConfigModel = jwtConfigModel;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin loginInfo)
        {
            if (ModelState.IsValid)
            {
                User user = await _userRepository.GetUser(x => x.Email == loginInfo.Email && x.Password == loginInfo.Password);
                if (user != null)
                {
                    var token = GenerateJwtToken(user);
                    return Ok(new { token });
                }
                else
                {
                    return NotFound("Wrong login credentials");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        private string GenerateJwtToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfigModel.Secret));

                ClaimsIdentity Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Email", user.Email),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = Subject,
                    Expires = DateTime.Now.AddHours(_jwtConfigModel.ExpireDays),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);             
            }
            catch (Exception ex)
            {

                return null;
            }


        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //    new Claim("UserId", user.Id.ToString()),
        //    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //};

            //var key =
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //var token = new JwtSecurityToken(
            //    issuer: _jwtConfigModel.Issuer,
            //    audience: _jwtConfigModel.Audience,
            //    claims: claims,
            //    expires: DateTime.Now.AddHours(_jwtConfigModel.ExpireDays),
            //    signingCredentials: creds);

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
