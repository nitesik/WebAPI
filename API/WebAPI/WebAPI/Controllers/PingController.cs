using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
public class PingController : ControllerBase
{
	[HttpGet]
	[Route("/ping")]
	public IActionResult GetPing()
	{
		return Ok(new { Response = "Pong" });
	}

	[HttpGet]
	[Route("/protectedping")]
	[Authorize]
	public IActionResult GetProtectedPong()
	{
		return Ok(new { Responses = "Protected Ponged" });
	}
}

