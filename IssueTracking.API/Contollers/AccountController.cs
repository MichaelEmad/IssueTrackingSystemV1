using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IssueTracking.Application.DTO;
using IssueTracking.Domain.Entities.UserAggregate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracking.API.Contollers
{
    [ApiController]
    [Authorize]
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody]UserRegistrationDto userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new User {Email = userModel.Email, UserName = userModel.FullName};
            IdentityResult result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userModel)
        {
            var user = await _userManager.FindByEmailAsync(userModel.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, userModel.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));
                  return  RedirectToAction("GetAllProject","Project");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
