using WebAPI.Models.API;
using WebAPI.Models.API.Domain;

namespace WebAPI.Repository;

public interface IUsersRepository
{
	Task InsertUserAsync(UserSignup user);
	// Task<string> LoginUserAsync(UserLogin login);
	Task<User> GetUserByEmail(string email);
}