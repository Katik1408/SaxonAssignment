using Microsoft.AspNetCore.Mvc;
using Saxon.Application.Data;
using Saxon.Application.Services.Contract;

namespace SaxonAPI.Controllers
{

    [Route("/api")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public readonly IAccountService signUpUserService;

        public AccountController(IAccountService signUpUserService)
        {
            this.signUpUserService = signUpUserService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signUpDTO"></param>
        /// <returns></returns>
        [HttpPost, Route("signupuser")]
        public IActionResult SignUpUser(SignUpDTO signUpDTO) =>
        Ok(this.signUpUserService.RegisterNewUserService(signUpDTO));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost, Route("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Invalid client request");
            }
            return Ok(new {token =  this.signUpUserService.LoginUserService(loginDto) });
        }
    }
}
