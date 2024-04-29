using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Models.Requests;
using System.Text;
using Paradigmi.Enterprise.Application.Options;
using Microsoft.Extensions.Options;

namespace Paradigmi.Enterprise.Application.Services
{
	public class TokenService : ITokenService
	{
		private readonly JwtAuthenticationOption _jwtAuthOption;

		public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption)
		{
			_jwtAuthOption = jwtAuthOption.Value;
		}

		public string CreateToken(CreateTokenRequest request)
		{
			//STEP 1 : Verificare esattezza della coppia username/password
			//TODO : Effettuare la verifica
			//STEP 2 : Se username/password corrette creo il token con le claims necessarie
			//TODO : Prendere i parametri dalla configurazione
			//TODO : Prendere le claims dal database

			List<Claim> claims = new List<Claim>();
			claims.Add(new Claim("Nome", "Elia"));
			claims.Add(new Claim("Cognome", "Toma"));
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
			//STEP 3 : Restituisco il token
			return token;
		}
	}
}
