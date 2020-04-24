using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using PlantsApi.Models.ViewModels;

namespace PlantsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IUsersRepository usersRepository;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IUsersRepository usersRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.usersRepository = usersRepository;
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (signInResult.Succeeded) { return Ok(); }
            }
            return Unauthorized();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");
            return Ok();
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("Login")]
        [ActionName("Login")]
        public async Task<IActionResult> LoginGet(string Username, string Password)
        {
            var user = await userManager.FindByNameAsync(Username);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                var signInResult = await signInManager.PasswordSignInAsync(user, Password, false, false);
                if (signInResult.Succeeded) { return Ok(); }
            }
            return Unauthorized();
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("Logout")]
        [ActionName("Logout")]
        public async Task<IActionResult> LogoutGet()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] LoginModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, model.Password);
            usersRepository.CreateUser(user, model.Password);
            if (result.Succeeded) { return Ok(); }
            else
            {
                // TODD: Add validation errors
                return BadRequest();
            }
        }
    }
}
