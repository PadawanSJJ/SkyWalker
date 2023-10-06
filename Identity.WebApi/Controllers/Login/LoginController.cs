using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyWalker.Common;
using SkyWalker.IService;
using SkyWalker.Models;
using System.Text;

namespace Identity.WebApi.Controllers.Login
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICitizenService _citizenService;
        public LoginController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
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
            return Ok("Sign In Successfully!");
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
