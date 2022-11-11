using WebAPI.Models.API;
using WebAPI.Repository;

namespace WebAPI.Services;

public class ProductService : IProductService
{
	private readonly IProductRepository _productRepository;

	public ProductService(IProductRepository productRepository)
	{
		_productRepository = productRepository;
	}
	public async Task<List<Product>> GetProducts()
	{
		return await _productRepository.GetProducts();
	}

	public async Task<Product> GetProduct(string id)
	{
		return await _productRepository.GetProduct(id);
	}
	
}