using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Models.Requests;
using System.Text;
using Paradigmi.Enterprise.Application.Options;
using Microsoft.Extensions.Options;
using Paradigmi.Enterprise.Models.Repositories;

namespace Paradigmi.Enterprise.Application.Services
{
	public class TokenService : ITokenService
	{
		private readonly JwtAuthenticationOption _jwtAuthOption;
		private readonly TokenRepository _tokenRepository;

		public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption, TokenRepository tokenRepository)
		{
			_jwtAuthOption = jwtAuthOption.Value;
			_tokenRepository = tokenRepository;
		}

		public string CreateToken(CreateTokenRequest request)
		{
			var utente = _tokenRepository.getUtenteDaDB(request.Email, request.Password);

			List<Claim> claims = new List<Claim>();

			if (utente != null)
			{
				claims.Add(new Claim("Nome", utente.Nome));
				claims.Add(new Claim("Cognome", utente.Cognome));
			}
			else
			{
				throw new Exception("Utente non trovato");
			}

			var securityKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
				);
			var credentials = new SigningCredentials(securityKey
				, SecurityAlgorithms.HmacSha256);

			var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
				, null
				, claims
				, expires: DateTime.Now.AddMinutes(30)
				, signingCredentials: credentials
				);

			var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

			return token;
		}
	}
}
