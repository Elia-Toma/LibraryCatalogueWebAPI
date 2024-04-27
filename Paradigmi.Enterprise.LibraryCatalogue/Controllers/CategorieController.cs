using Microsoft.AspNetCore.Mvc;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Models.Requests;
using Paradigmi.Enterprise.Application.Models.Responses;
using Paradigmi.Enterprise.Application.Models.Dtos;

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
		public IActionResult CreateCategoria(CreateCategoriaRequest request)
		{
			var categoria = request.ToEntity();
			_categoriaService.CreateCategoria(categoria);

			var response = new CreateCategoriaResponse();
			response.Categoria = new CategoriaDto(categoria);
			return Ok(response);
		}

		[HttpDelete]
		[Route("delete/{id:int}")]
		public IActionResult DeleteCategoria(int id)
		{
			_categoriaService.DeleteCategoriaVuota(id);
			return Ok();
		}
	}
}
