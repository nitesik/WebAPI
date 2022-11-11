using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using WebAPI.Models.API;
namespace WebAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
[EnableCors("_allowedOrigin")]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductsController(IProductService productService)
	{
		_productService = productService;
	}
	// GET
	[HttpGet]
	public IActionResult Get()
	{
		var product = _productService.GetProducts();
		return Ok(product);
	}

	[HttpGet]
	[Route("{id}")]
	public IActionResult GetProduct(string id)
	{
		var product = _productService.GetProduct(id);
		return Ok(product);
	}
}