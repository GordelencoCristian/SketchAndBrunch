using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Entities;
using SharedData.Models;
using SharedData.Services.EmailSender;

namespace BackOffice.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSenderService _emailSender;
        private readonly string _defaultPassword = "Parola11a#";
        private readonly AppDbContext _appDbContext;

        public AuthorizeController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IEmailSenderService emailSender, 
            AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginParameters parameters)
        {
            var user = await _userManager.FindByNameAsync(parameters.UserName);

            if (user == null) return BadRequest("User does not exist");

            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, parameters.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");

            await _signInManager.SignInAsync(user, parameters.RememberMe);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameters parameters)
        {
            var existentApplicationUser = await _userManager.FindByNameAsync(parameters.UserName);

            if (existentApplicationUser != null) await _userManager.DeleteAsync(existentApplicationUser);

            var user = new ApplicationUser
            {
                UserName = parameters.UserName
            };
           
            var result = await _userManager.CreateAsync(user, _defaultPassword);

            if (result.Succeeded)
            {
                await _emailSender.SendEmailAsync(user.UserName, "New User", GetEmailMessage(user?.Email, _defaultPassword));
            }

            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            return Redirect("https://localhost:7245/login");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<UserInfo> UserInfo()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            return BuildUserInfo(user);
        }


        private UserInfo BuildUserInfo(ApplicationUser applicationUser)
        {
            return new UserInfo
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                //UserId = applicationUser.UserProfile.Id,
                ExposedClaims = User.Claims
                    .ToDictionary(c => c.Type, c => c.Value)
            };
        }

        private string GetEmailMessage(string email, string password)
        {
            return $"Buna, a fost creat un cont nou pentru SISBR (Informational System Barber Shop) <br>" +
                   $"User Name: {email} <br> sisbrinfo@gmail.com" +
                   $"Password: {password} <br>";

        }
    }
}
