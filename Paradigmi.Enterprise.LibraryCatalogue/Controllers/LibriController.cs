using Microsoft.AspNetCore.Mvc;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Models.Requests;
using Paradigmi.Enterprise.Application.Models.Responses;
using Paradigmi.Enterprise.Application.Models.Dtos;
using Paradigmi.Enterprise.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Paradigmi.Enterprise.LibraryCatalogue.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class LibriController : ControllerBase
	{
		private readonly ILibroService _libroService;

		public LibriController(ILibroService libroService)
		{
			_libroService = libroService;
		}

		[HttpDelete]
		[Route("delete/{id:int}")]
		public IActionResult DeleteLibro(int id)
		{
			_libroService.DeleteLibro(id);
			return Ok();
		}

		[HttpPost]
		[Route("new")]
		public IActionResult CreateLibro(CreateLibroRequest request)
		{
			// Su Swagger si possono aggiungere più categorie
			// Swagger restituisce un errore ma l'API funziona, i dati vengono inseriti correttamente
			var libro = request.ToEntity();
			_libroService.CreateLibro(libro, request.NomiCategorie);

			var response = new CreateLibroResponse();
			response.Libro = new LibroDto(libro);
			return Ok(response);
		}
		
		[HttpPut]
		[Route("update")]
		public IActionResult UpdateLibro(UpdateLibroRequest request)
		{
			var libro = request.ToEntity();
			_libroService.UpdateLibro(request.IdLibro, libro);

			var response = new UpdateLibroResponse();
			response.Libro = new LibroDto(libro);
			return Ok(response);
		}

		[HttpGet]
		[Route("get/nome")]
		public Libro GetLibroDaNome(string nome)
		{
			return _libroService.GetLibroDaNome(nome);
		}

		[HttpPost]
		[Route("get/autore")]
		public IActionResult GetLibriDaAutore(GetLibriDaAutoreRequest request)
		{
			int totalNum = 0;
			var libri = _libroService.GetLibriDaAutore(request.PageNumber * request.PageSize, request.PageSize, request.Autore, out totalNum);

			var response = new GetLibriResponse();
			var pageFounded = (totalNum / (decimal)request.PageSize);
			response.NumeroPagine = (int)Math.Ceiling(pageFounded);
			response.Libri = libri.Select(l => new LibroDto(l)).ToList();

			return Ok(response);
		}

		[HttpPost]
		[Route("get/categoria")]
		public IActionResult GetLibriDaCategoria(GetLibriDaCategoriaRequest request)
		{
			int totalNum = 0;
			var libri = _libroService.GetLibriDaCategoria(request.PageNumber * request.PageSize, request.PageSize, request.Categoria, out totalNum);

			var response = new GetLibriResponse();
			var pageFounded = (totalNum / (decimal)request.PageSize);
			response.NumeroPagine = (int)Math.Ceiling(pageFounded);
			response.Libri = libri.Select(l => new LibroDto(l)).ToList();

			return Ok(response);
		}

		[HttpPost]
		[Route("get/data")]
		public IActionResult GetLibriDaDataPubblicazione(GetLibriDaDataPubblicazioneRequest request)
		{
			int totalNum = 0;
			var libri = _libroService.GetLibriDaDataPubblicazione(request.PageNumber * request.PageSize, request.PageSize, request.DataPubblicazione, out totalNum);

			var response = new GetLibriResponse();
			var pageFounded = (totalNum / (decimal)request.PageSize);
			response.NumeroPagine = (int)Math.Ceiling(pageFounded);
			response.Libri = libri.Select(l => new LibroDto(l)).ToList();

			return Ok(response);
		}
	}
}
