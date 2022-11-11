using WebAPI.Models.API;
namespace WebAPI.Services;

public interface IProductService
{
	Task<List<Product>> GetProducts();
	Task<Product> GetProduct(string id);
}