using WebAPI.Models.API;

namespace WebAPI.Repository;

public interface IProductRepository
{
	public List<Product> GetProducts();
	Product GetProduct(string id);
}