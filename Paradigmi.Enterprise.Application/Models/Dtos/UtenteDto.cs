using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Models.Dtos
{
	public class UtenteDto
	{
		public UtenteDto()
		{
		}

		public UtenteDto(Utente utente)
		{
			Id = utente.IdUtente;
			Email = utente.Email;
			Nome = utente.Nome;
			Cognome = utente.Cognome;
			Password = utente.Password;
		}

		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Nome { get; set; } = string.Empty;
		public string Cognome { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
