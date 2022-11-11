using WebAPI.Models.API;
using WebAPI.Models.API.Domain;

namespace WebAPI.Services;

public interface IUserService
{
	Task InsertUserAsync(UserSignup user);
	Task<User> LoginUserAsync(TokenRequest login);
}