using Microsoft.AspNetCore.Mvc;
using Paradigmi.Enterprise.Application.Abstractions.Services;

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
	}
}
