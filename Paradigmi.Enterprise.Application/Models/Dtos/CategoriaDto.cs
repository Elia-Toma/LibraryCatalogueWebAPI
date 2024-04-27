using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Models.Dtos
{
	public class CategoriaDto
	{
		public CategoriaDto()
		{
		}

		public CategoriaDto(Categoria categoria)
		{
			Id = categoria.IdCategoria;
			Nome = categoria.Nome;
		}

		public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
	}
}
