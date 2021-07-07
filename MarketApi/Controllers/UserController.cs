using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _singInUser;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            _singInUser = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel loginModel)
        {
            IActionResult response = Unauthorized();
            var success = AuthenticateUser(loginModel);

            if (success)
            {
                var tokenString = GenerateJsonWebToken(loginModel);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserModel loginModel)
        {
            var success = await RegisterUser(loginModel);

            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<bool> RegisterUser(UserModel registerModel)
        {
            var user = new IdentityUser { UserName = registerModel.Email, Email = registerModel.Email };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                bool x = await _roleManager.RoleExistsAsync("Admin");
                if (!x)
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    role.Id = "Admin";
                    role.NormalizedName = "ADMIN";
                    await _roleManager.CreateAsync(role);

                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    bool y = await _roleManager.RoleExistsAsync("User");
                    if (!y)
                    {
                        var role = new IdentityRole();
                        role.Id = "User";
                        role.Name = "User";
                        role.NormalizedName = "USER";
                        await _roleManager.CreateAsync(role);

                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                }
            }
            return result.Succeeded;
        }

        private object GenerateJsonWebToken(UserModel loginModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool AuthenticateUser(UserModel loginModel)
        {
            var result = _singInUser.PasswordSignInAsync(loginModel.Email, loginModel.Password, true, false).Result;

            return result.Succeeded;
        }
    }
}
