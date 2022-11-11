using WebAPI.Models.API;

namespace WebAPI.Repository;

public interface IProductRepository
{
	public Task<List<Product>> GetProducts();
	Task<Product> GetProduct(string id);
}