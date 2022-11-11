using System.Data;
using System.Data.SqlClient;
using WebAPI.Models.API;
using System.Linq;
using Dapper;

namespace WebAPI.Repository;

public class ProductRepository : IProductRepository
{
	public async Task<Product> GetProduct(string id)
	{
		List<Product> products = await GetProducts();

		return products.Where(p => p.Id == Convert.ToInt32(id)).FirstOrDefault();

	}
	
	public async Task<List<Product>> GetProducts()
	{
		try
		{
			List<Product> products = new List<Product>();

			using (var connection = new SqlConnection("server=localhost;database=savijsell;trusted_connection=true"))
			{
				// var parameters = new DynamicParameters();
				// parameters.Add();

				var results = await connection.QueryAsync<Product>("stp_Items_Get", null, commandType: CommandType.StoredProcedure);
				if (results != null)
					return results.ToList();

				return null;


			}
		}
		catch (Exception error)
		{
			Console.WriteLine(error);
			throw;
		}
		
	}
}