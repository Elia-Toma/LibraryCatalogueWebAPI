using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Models.Entities;
using Paradigmi.Enterprise.Models.Repositories;

namespace Paradigmi.Enterprise.Application.Services
{
	public class UtenteService : IUtenteService
	{
		private readonly UtenteRepository _utenteRepository;

		public UtenteService(UtenteRepository utenteRepository)
		{
			_utenteRepository = utenteRepository;
		}

		public void CreateUtente(Utente utente)
		{
			_utenteRepository.Aggiungi(utente);
			_utenteRepository.Save();
		}
	}
}
