using WebAPI.Models.API;
using System.Linq;
namespace WebAPI.Repository;

public class ProductRepository : IProductRepository
{
	public Product GetProduct(string id)
	{
		List<Product> products = GetProducts();

		return products.Where(p => p.Id == Convert.ToInt32(id)).FirstOrDefault();

	}
	public List<Product> GetProducts()
	{
		List<Product> products = new List<Product>();
		
		products.Add(new Product()
		{
			Id = 1,
			Title = "Black Bag",
			Description = "A black bag - nice",
			Image = $"/assets/images/1.jpg",
			Location = $"{LoremNETCore.Generate.Words(1)}"
		});
		products.Add(new Product()
		{
			Id = 2,
			Title = "Red Bag",
			Description = "A red bag - nice",
			Image = $"/assets/images/2.jpg",
			Location = $"{LoremNETCore.Generate.Words(1)}"
		});
		products.Add(new Product()
		{
			Id = 3,
			Title = "Green Bag",
			Description = "A Green bag - nice",
			Image = $"/assets/images/3.jpg",
			Location = $"{LoremNETCore.Generate.Words(1)}"
		});
		products.Add(new Product()
		{
			Id = 4,
			Title = "Blue Bag",
			Description = "A Blue bag - nice",
			Image = $"/assets/images/4.jpg",
			Location = $"{LoremNETCore.Generate.Words(1)}"
		});
		products.Add(new Product()
		{
			Id = 5,
			Title = "Yellow Bag",
			Description = "A Yellow bag - nice",
			Image = $"/assets/images/5.jpg",
			Location = $"{LoremNETCore.Generate.Words(1)}"
		});

		return products;
	}
}