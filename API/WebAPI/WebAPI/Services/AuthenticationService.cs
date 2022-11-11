using System.Security.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models.API;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebAPI.Services;

public class AuthenticationService : IAuthenticationService
{
	private readonly IUserService _userService;
	private const string JwtSigningKey = "r/b2NzaAxi7kzNTOPZTvio8o9uxVTvb0GL6Y2bzMQtc=";

	public AuthenticationService(IUserService userService)
	{
		_userService = userService;
	}

	public async Task<TokenResponse> RequestTokenAsync(TokenRequest tokenRequest)
	{
		var user = await _userService.LoginUserAsync(tokenRequest);
		if (user != null)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.Email, user.Email)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSigningKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			
			var token = new JwtSecurityToken
			(
				issuer: "localhost:7058",
				audience: "localhost:7058",
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds
				
			);

			return new TokenResponse()
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token)
			};
		}

		throw new AuthenticationException();
	}
	
}
