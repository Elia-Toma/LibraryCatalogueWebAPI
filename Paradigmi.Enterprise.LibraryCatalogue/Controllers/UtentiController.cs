using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Models.Dtos;
using Paradigmi.Enterprise.Application.Models.Requests;
using Paradigmi.Enterprise.Application.Models.Responses;

namespace Paradigmi.Enterprise.LibraryCatalogue.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class UtentiController : ControllerBase
	{
		private readonly IUtenteService _utenteService;

		public UtentiController(IUtenteService utenteService)
		{
			_utenteService = utenteService;
		}

		[HttpPost]
		[Route("new")]
		public IActionResult CreateUtente(CreateUtenteRequest request)
		{
			var utente = request.ToEntity();
			_utenteService.CreateUtente(utente);

			var response = new CreateUtenteResponse();
			response.Utente = new UtenteDto(utente);
			return Ok(response);
		}
	}
}
