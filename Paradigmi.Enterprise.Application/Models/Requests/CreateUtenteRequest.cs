using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Models.Requests
{
	public class CreateUtenteRequest
	{
		public string Email { get; set; } = string.Empty;
		public string Nome { get; set; } = string.Empty;
		public string Cognome { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		public Utente ToEntity()
		{
			var utente = new Utente
			{
				Email = Email,
				Nome = Nome,
				Cognome = Cognome,
				Password = Password
			};

			return utente;
		}
	}
}
