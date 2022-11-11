using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.API;
using WebAPI.Services;
using WebAPI.Models.API.Domain;

namespace WebAPI.Controllers;

[ApiController]
public class UsersController : ControllerBase
{

	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		_userService = userService;
	}
	
	// Post
	// TODO Complete this! 
	[HttpPost]
	[Route("api/Signup")]
	public async Task<IActionResult> Post(UserSignup user)
	{
		await _userService.InsertUserAsync(user);
		return NoContent();
	}

	
}