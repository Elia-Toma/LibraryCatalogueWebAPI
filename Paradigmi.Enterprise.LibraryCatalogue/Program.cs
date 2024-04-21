using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Services;
using Paradigmi.Enterprise.LibraryCatalogue.Data;
using Paradigmi.Enterprise.Models.Context;
using Paradigmi.Enterprise.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Le astrazioni sono importanti per i middleware
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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

	ctx.Libri.Add(libro);
	ctx.SaveChanges();
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