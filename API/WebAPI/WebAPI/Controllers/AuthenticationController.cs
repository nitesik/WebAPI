// using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using WebAPI.Models.API;

namespace WebAPI.Controllers;

[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly IAuthenticationService _authenticationService;

	public AuthenticationController(IAuthenticationService authenticationService)
	{
		_authenticationService = authenticationService;
	}
	// GET
	[HttpPost]
	[Route("api/token")]
	async public Task<IActionResult> RequestToken(TokenRequest tokenRequest)
	{
		var token = await _authenticationService.RequestTokenAsync(tokenRequest);
		return Ok(token);
	}
}