using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Enterprise.LibraryCatalogue.Data;
using Paradigmi.Enterprise.Models.Context;
using Paradigmi.Enterprise.Models.Entities;
/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
*/





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