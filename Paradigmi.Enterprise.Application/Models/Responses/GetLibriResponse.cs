using Paradigmi.Enterprise.Application.Models.Dtos;

namespace Paradigmi.Enterprise.Application.Models.Responses
{
	public class GetLibriResponse
	{
		public List<LibroDto> Libri { get; set; } = new List<LibroDto>();
		public int NumeroPagine { get; set; }
	}
}
