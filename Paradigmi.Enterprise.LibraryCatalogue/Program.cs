using System.Data.SqlClient;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Services;
using Paradigmi.Enterprise.LibraryCatalogue.Data;
using Paradigmi.Enterprise.Models.Context;
using Paradigmi.Enterprise.Models.Entities;
using Paradigmi.Enterprise.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(
	AppDomain.CurrentDomain.GetAssemblies().
		SingleOrDefault(assembly => assembly.GetName().Name == "Paradigmi.Enterprise.Application")
	);

builder.Services.AddDbContext<MyDbContext>(options =>
{
	options.UseSqlServer("data source=localhost;Initial catalog=ProgettoEnterprise;User Id=enterprise;Password=enterprise;TrustServerCertificate=True");
});

// Le astrazioni sono importanti per i middleware
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<UtenteRepository>();

builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<LibroRepository>();

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<CategoriaRepository>();

builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();



/*


// TEST COLLEGAMENTO DB

// Aggiungo delle categorie

List<Categoria> listaCategorie = new List<Categoria>
{
	new Categoria { Nome = "Fisica" },
	new Categoria { Nome = "Astronomia" }
};

foreach (var categoria in listaCategorie) // La lista è di categorie
{
	using (var ctx = new MyDbContext())
	{
		ctx.Categorie.Add(categoria);
		ctx.SaveChanges();
	}
}

// Aggiungo un libro

using (var ctx = new MyDbContext())
{

	LibroRepository libroRepository = new LibroRepository(ctx);

	var libro = new Libro
	{
		Nome = "Inseguendo un raggio di luce",
		Autore = "Amedeo Balbi",
		DataPubblicazione = new DateTime(2021, 9, 28),
		Editore = "Rizzoli",
		Categorie = new List<LibroCategoria> // Le categorie vengono aggiunte automaticamente anche al db, nella tabella LibriCategorie
		{
			new LibroCategoria
			{
				Categoria = ctx.Categorie.First(c => c.Nome == "Fisica")
			},
			new LibroCategoria
			{
				Categoria = ctx.Categorie.First(c => c.Nome == "Astronomia")
			}
		}
	};

	libroRepository.Aggiungi(libro);
	libroRepository.Save();
}

// Modifica di un libro

using (var ctx = new MyDbContext())
{
	LibroRepository libroRepository = new LibroRepository(ctx);

	var libro = ctx.Libri.First(l => l.Nome == "Inseguendo un raggio di luce");
	libro.Autore = "Amedeo Balbi astrofisico";
	libroRepository.Modifica(libro);
	libroRepository.Save();
}

// Eliminazione di un libro

using (var ctx = new MyDbContext())
{
	LibroRepository libroRepository = new LibroRepository(ctx);

	var libro = ctx.Libri.First(l => l.Nome == "Inseguendo un raggio di luce");

	// Elimino le categorie associate al libro (se non lo faccio, non posso eliminare il libro)
	//ctx.LibriCategorie.RemoveRange(ctx.LibriCategorie.Where(lc => lc.IdLibro == libro.IdLibro));

	libroRepository.DeleteLibro(libro.IdLibro); // Mio metodo
	libroRepository.Save();
}

{
	var ctx = new MyDbContext();
	var libri = ctx.Libri.ToList();
	var categorie = ctx.Categorie.ToList();
	var libriCategorie = ctx.LibriCategorie.ToList();
}

/*
 * Vedere EntityFrameworkExample nel progetto del prof per le Query di filtro e i metodi add, edit e tutto il resto
 * Il prof usa la sintassi fluida
*/