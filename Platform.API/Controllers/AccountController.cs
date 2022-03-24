//using DataAccess.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using Models.DTOs;
//using Platform.API.Helper;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Platform.API.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    [Authorize]
//    public class AccountController : Controller
//    {
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly APISettings _apiSettings;

//        public AccountController(SignInManager<ApplicationUser> signInManager,
//            UserManager<ApplicationUser> userManager,
//            RoleManager<IdentityRole> roleManager,
//            IOptions<APISettings> apiSettings)
//        {
//            _signInManager = signInManager;
//            _userManager = userManager;
//            _roleManager = roleManager;
//            _apiSettings = apiSettings.Value;
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<IActionResult> SignUp([FromBody] UserRequestDto userRequestDto)
//        {
//            if (userRequestDto == null || !ModelState.IsValid)
//            {
//                return BadRequest();
//            }

//            var user = new ApplicationUser
//            {
//                UserName = userRequestDto.Email,
//                Email = userRequestDto.Email,
//                FirstName = userRequestDto.FirstName,
//                LastName = userRequestDto.LastName,
//                EmailConfirmed = true
//            };

//            var result = await _userManager.CreateAsync(user, userRequestDto.Password);

//            if (!result.Succeeded)
//            {
//                var error = result.Errors.Select(e => e.Description);
//                return BadRequest(new RegistrationResponseDto
//                {
//                    IsRegistrationSuccessful = false,
//                    Errors = error
//                });

//                var roleResult = await _userManager.AddToRoleAsync(user, "Customer");

//                if (!roleResult.Succeeded)
//                {
//                    return BadRequest(new RegistrationResponseDto
//                    {
//                        IsRegistrationSuccessful = false,
//                        Errors = error
//                    });
//                }
//            }

//            return StatusCode(201);
//        }

//        [AllowAnonymous]
//        [HttpPost]
//        public async Task<IActionResult> SignIn([FromBody] AuthenticationDto authenticationDto)
//        {
//            var result = await _signInManager.PasswordSignInAsync(authenticationDto.Email, 
//                authenticationDto.Password, false, false);

//            if (result.Succeeded)
//            {
//                var user = await _userManager.FindByNameAsync(authenticationDto.Email);
//                if (user == null)
//                {
//                    return Unauthorized(new AuthenticationResponseDto
//                    {
//                        IsAuthSuccessful = false,
//                        ErrorMessage = "Invalid Access"
//                    });
//                }

//                var signingCredentials = GetSigningCredentials();
//                var claims = await GetClaims(user);

//                var tokenOptions = new JwtSecurityToken(
//                    issuer: _apiSettings.ValidIssuer,
//                    audience: _apiSettings.ValidAudience,
//                    claims: claims,
//                    expires: DateTime.Now.AddDays(30),
//                    signingCredentials: signingCredentials);

//                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
//                return Ok(new AuthenticationResponseDto
//                {
//                    IsAuthSuccessful = true,
//                    Token = token,
//                    user = new UserDto
//                    {
//                        Id = user.Id,
//                        FirstName = user.FirstName,
//                        LastName = user.LastName,
//                        Email = user.Email,
//                        PhoneNumber = user.PhoneNumber,
//                    }
//                });
//            }
//            else 
//            {
//                return Unauthorized(new AuthenticationResponseDto
//                {
//                    IsAuthSuccessful = false,
//                    ErrorMessage = "Invalid Authentication"
//                });
//            }
//        }

//        private SigningCredentials GetSigningCredentials()
//        {
//            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiSettings.SecretKey));
//            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
//        }

//        private async Task<List<Claim>> GetClaims(ApplicationUser user)
//        {
//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.Name, user.Email),
//                new Claim(ClaimTypes.Email, user.Email),
//                new Claim("Id", user.Id),
//            };

//            var applicationUser = await _userManager.FindByEmailAsync(user.Email);
//            var roles = await _userManager.GetRolesAsync(applicationUser);

//            foreach (var role in roles)
//            {
//                claims.Add(new Claim(ClaimTypes.Role, role));
//            }
//            return claims;
//        }
//    }
//}
