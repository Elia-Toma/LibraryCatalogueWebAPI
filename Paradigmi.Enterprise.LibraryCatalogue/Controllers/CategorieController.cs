using Microsoft.AspNetCore.Mvc;
using Paradigmi.Enterprise.Application.Abstractions.Services;

namespace Paradigmi.Enterprise.LibraryCatalogue.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CategorieController : ControllerBase
	{
		private readonly ICategoriaService _categoriaService;

		public CategorieController(ICategoriaService categoriaService)
		{
			_categoriaService = categoriaService;
		}

		[HttpPost]
		[Route("new")]
		public IActionResult CreateCategoria(string nome)
		{
			_categoriaService.CreateCategoria(nome);
			return Ok();
		}
	}
}
