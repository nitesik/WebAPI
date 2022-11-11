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
	public List<Product> GetProducts()
	{
		return _productRepository.GetProducts();
	}

	public Product GetProduct(string id)
	{
		return _productRepository.GetProduct(id);
	}
	
}