using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Models.Requests
{
	public class CreateCategoriaRequest
	{
		public string Nome { get; set; } = string.Empty;

		public Categoria ToEntity()
		{
			return new Categoria
			{
				Nome = Nome
			};
		}
	}
}
