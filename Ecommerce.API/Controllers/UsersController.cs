using Ecommerce.BL.Dtos.Users;
using Ecommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly UserManager<User> _userManager;

		public UsersController(IConfiguration configuration,
			UserManager<User> userManager)
		{
			_configuration = configuration;
			_userManager = userManager;
		}

		#region Register

		[HttpPost]
		[Route("register")]
		public async Task<ActionResult> Register(RegisterDto registerDto)
		{
			var user = new User
			{
				UserName = registerDto.UserName,
				Email = registerDto.Email
				
			};
			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (!result.Succeeded)
			{
				return BadRequest(result.Errors); // 400, Errors
			}

			var claims = new List<Claim>
		{
			new (ClaimTypes.NameIdentifier, user.Id.ToString()),
			new (ClaimTypes.Name, user.UserName),
			new (ClaimTypes.Email, user.Email),
			
		};
			await _userManager.AddClaimsAsync(user, claims);

			return NoContent();
		}

		#endregion


		#region Login

		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.UserEmail);
			if (user == null)
			{
				return Unauthorized(); // 401
			}

			bool isAuthenticated = await _userManager.CheckPasswordAsync(user, loginDto.Password);
			if (!isAuthenticated)
			{
				return Unauthorized(); // 401
			}

			var userClaims = await _userManager.GetClaimsAsync(user);

			return GenerateToken(userClaims);
		}

		#endregion

		#region Helpers

		private ActionResult<TokenDto> GenerateToken(IEnumerable<Claim> userClaims)
		{
			var keyFromConfig = _configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
			var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
			var key = new SymmetricSecurityKey(keyInBytes);

			var signingCredentials = new SigningCredentials(key,
				SecurityAlgorithms.HmacSha256Signature);

			var expiryDateTime = DateTime.Now.AddMinutes(40);

			var jwt = new JwtSecurityToken(
				claims: userClaims,
				expires: expiryDateTime,
				signingCredentials: signingCredentials);

			var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);

			return new TokenDto(jwtAsString, expiryDateTime);
		}

		#endregion
	}
}
