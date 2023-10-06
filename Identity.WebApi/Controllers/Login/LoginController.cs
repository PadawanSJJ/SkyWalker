using Identity.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkyWalker.Common;
using SkyWalker.IService;
using SkyWalker.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.WebApi.Controllers.Login
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICitizenService _citizenService;

        private readonly IConfiguration _configuration;
        public LoginController(ICitizenService citizenService,IConfiguration configuration)
        {
            _citizenService = citizenService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult> SignIn([FromForm] string email, [FromForm] string password)
        {
            var isEmail = email.Contains("@");
            var query = isEmail ?
                await _citizenService.QueryByEmailAsync(email) :
                await _citizenService.QueryByPhoneNoAsync(email);
            if (query is null)
            {
                return BadRequest("No Citizen Info Found!");
            }
            var ciphertext = MD5Helper.MD5Encrypt32(password);
            if (ciphertext!= query.Password)
            {
                return BadRequest("Wrong Password!");
            }
            JwtOptions jwtOptions = _configuration.GetSection("JWT").Get<JwtOptions>();

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier,query.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name,query.Name.ToString()));
            
            TimeSpan ExpiryDuration = TimeSpan.FromSeconds(jwtOptions.ExpireSeconds);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(jwtOptions.Issuer, jwtOptions.Audience, claims,
                expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
            var token= new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return Ok(token);
        }
        [HttpPost]
        public async Task<ActionResult> SignUp([FromBody] CitizenRegistrationModel model)
        {
            var valid =await _citizenService.QueryByEmailAsync(model.Email) is  null && await  _citizenService.QueryByPhoneNoAsync(model.PhoneNo) is  null;      
            if (!valid)
            {
                return BadRequest("Email/PhoneNumber has been used!");
            }
            var result = await _citizenService.CreateAsync(new Citizen() 
            {
                Email = model.Email,
                PhoneNo = model.PhoneNo,
                Name=model.Name,
                Password =MD5Helper.MD5Encrypt32(model.Password),
                State=0,
                RegisterTime=DateTime.Now,
                Avatar=string.Empty
            });
            if (!result)
            {
                return BadRequest("Failed to create!");
            }
            return Ok("Register Successfully!");

        }
    }
}
