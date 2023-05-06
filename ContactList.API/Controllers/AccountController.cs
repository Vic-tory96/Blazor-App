using Azure;
using ContactBookModels;
using ContactList.API.Details;
using ContactList.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace ContactList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAccountRepository _accountRepository;

        public AccountController(IConfiguration configuration, UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager, IAccountRepository accountRepository
        )
        {
            _configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _accountRepository = accountRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDetails model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "User Already Exist" });


            IdentityUser res = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,

            };

            var result = await userManager.CreateAsync(res, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "User Creation Failed" });
            }

            return Ok(new Responses { Status = "Success", Message = "User Created Succesfully" });
           
            }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var result = await _accountRepository.LoginAsync(login);
                if (string.IsNullOrEmpty(result))
                {
                    return Unauthorized(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }

        }
    }
}
