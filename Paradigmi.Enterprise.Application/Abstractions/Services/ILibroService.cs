using Paradigmi.Enterprise.Models.Entities;

namespace Paradigmi.Enterprise.Application.Abstractions.Services
{
	public interface ILibroService
	{
		void DeleteLibro(int id);
		void CreateLibro(Libro libro);
		void UpdateLibro(Libro libro);
	}
}
