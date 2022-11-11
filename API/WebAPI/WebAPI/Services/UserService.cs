using WebAPI.Models.API;
using WebAPI.Models.API.Domain;
using WebAPI.Repository;
using System.Security.Authentication;

namespace WebAPI.Services;

public class UserService : IUserService
{
	private readonly IUsersRepository _usersRepository;

	public UserService(IUsersRepository usersRepository)
	{
		_usersRepository = usersRepository; 
	}

	public async Task InsertUserAsync(UserSignup user)
	{
		await _usersRepository.InsertUserAsync(user);
	}

	public async Task<User> LoginUserAsync(TokenRequest login)
	{
		var user = await _usersRepository.GetUserByEmail(login.Email);
		if (login.Password != user.Password)
		{
			throw new AuthenticationException();
		}

		if (user == null)
			throw new AuthenticationException();
		
		return user;
	}
}