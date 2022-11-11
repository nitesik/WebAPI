using System.Data;
using WebAPI.Models.API;
using System.Data.SqlClient;
using Dapper;
using WebAPI.Models.API.Domain;
using System.Linq;

namespace WebAPI.Repository;

public class UsersRepository : IUsersRepository
{
	public async Task InsertUserAsync(UserSignup user)
	{
		
		// Connect to the database

		try
		{
			using (var connection = new SqlConnection("server=localhost;database=savijsell;trusted_connection=true"))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@FirstName", user.FirstName);
				parameters.Add("@LastName", user.LastName);
				parameters.Add("@Email", user.Email);
				parameters.Add("@Password", user.Password);
				parameters.Add("@PostalCode", user.PostalCode);
				parameters.Add("@Username", user.Username);
				parameters.Add("@UserId", user.UserId);
				var results = await connection.ExecuteAsync("stp_Users_Insert", parameters, commandType: CommandType.StoredProcedure);
				Console.WriteLine(results);
			}
		}
		catch (Exception e)
		{
			Console.Write(e);
		}
	}

	public async Task<User> GetUserByEmail(string email)
	{
		try
		{
			using (var connection = new SqlConnection("server=localhost;database=savijsell;trusted_connection=true"))
			{
				var parameters = new DynamicParameters();
				parameters.Add("@Email", email);

				var results = await connection.QueryAsync<User>("stp_Users_GetByEmail", param: parameters, commandType: CommandType.StoredProcedure);
				
				if (results != null)
				{
					return results.FirstOrDefault();
				}
				return null;
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
}