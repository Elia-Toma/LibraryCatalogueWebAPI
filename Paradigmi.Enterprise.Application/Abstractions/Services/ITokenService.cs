using Paradigmi.Enterprise.Application.Models.Requests;

namespace Paradigmi.Enterprise.Application.Abstractions.Services
{
	public interface ITokenService
	{
		string CreateToken(CreateTokenRequest request);
	}
}
