using Microsoft.AspNetCore.Mvc;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Models.Requests;
using Paradigmi.Enterprise.Application.Models.Responses;
using Paradigmi.Enterprise.Application.Models.Dtos;
using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.LibraryCatalogue.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
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
			var libro = request.ToEntity();
			_libroService.CreateLibro(libro);

			var response = new CreateLibroResponse();
			response.Libro = new LibroDto(libro);
			return Ok(response);
		}
		
		/*
		[HttpPost]
		[Route("update")]
		public IActionResult UpdateLibro(int id, CreateLibroRequest request)
		{
			var libro = request.ToEntity();
			_libroService.UpdateLibro(libro);

			var response = new CreateLibroResponse();
			response.Libro = new LibroDto(libro);
			return Ok(response);
		}
		*/

		[HttpGet]
		[Route("get/nome")]
		public Libro GetLibroDaNome(string nome)
		{
			return _libroService.GetLibroDaNome(nome);
		}

		[HttpGet]
		[Route("get/autore")]
		public IActionResult GetLibriDaAutore(string autore)
		{
			var libri = _libroService.GetLibriDaAutore(autore);

			var response = new GetLibriResponse();
			response.Libri = libri.Select(l => new LibroDto(l)).ToList();
			return Ok(response);
		}

		[HttpGet]
		[Route("get/categoria")]
		public IActionResult GetLibriDaCategoria(string categoria)
		{
			var libri = _libroService.GetLibriDaCategoria(categoria);

			var response = new GetLibriResponse();
			response.Libri = libri.Select(l => new LibroDto(l)).ToList();
			return Ok(response);
		}
	}
}
