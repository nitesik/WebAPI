using WebAPI.Models.API;
namespace WebAPI.Services;

public interface IProductService
{
	List<Product> GetProducts();
	Product GetProduct(string id);
}