using WebAPI.Models.API;

namespace WebAPI.Services;

public interface IAuthenticationService
{
	public Task<TokenResponse> RequestTokenAsync(TokenRequest tokenRequest);
}