namespace Paradigmi.Enterprise.Application.Models.Requests
{
	public class GetLibriDaAutoreRequest
	{
		public int PageSize { get; set; } //Rappresenta la grandezza della pagina
		public int PageNumber { get; set; } //Identifica il numero della pagina ad indice 0

		public string? Autore { get; set; }
	}
}
