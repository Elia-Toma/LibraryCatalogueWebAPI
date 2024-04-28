using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Abstractions.Services
{
	public interface ILibroService
	{
		void DeleteLibro(int id);
		void CreateLibro(Libro libro, ICollection<string> nomiCategorie);
		void UpdateLibro(int id, Libro libro);
		Libro GetLibroDaNome(string nome);
		List<Libro> GetLibriDaAutore(int from, int num, string? autore, out int totalNum);
		List<Libro> GetLibriDaCategoria(int from, int num, string? categoria, out int totalNum);
		List<Libro> GetLibriDaDataPubblicazione(int from, int num, DateTime? data, out int totalNum);
	}
}
