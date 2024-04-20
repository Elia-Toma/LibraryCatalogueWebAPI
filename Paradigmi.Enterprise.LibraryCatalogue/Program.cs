using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paradigmi.Enterprise.LibraryCatalogue.Data;
using Paradigmi.Enterprise.Models.Context;
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

// Aggiungo una categoria

using (var connection = new SqlConnection())
{
	connection.ConnectionString = "Server=localhost;Database=ProgettoEnterprise;User Id=enterprise;Password=enterprise;";
	connection.Open();

	var cmd = new SqlCommand();
	cmd.Connection = connection;
	cmd.CommandText = "INSERT INTO Categorie(Nome) VALUES(@NOME);";
	cmd.Parameters.AddWithValue("@NOME", "Astronomia");
	cmd.ExecuteNonQuery();
}


// Aggiungo un libro
/*
using (var connection = new SqlConnection())
{
	connection.ConnectionString = "Server=localhost;Database=ProgettoEnterprise;User Id=enterprise;Password=enterprise;";
	connection.Open();

	var cmd = new SqlCommand();
	cmd.Connection = connection;
	cmd.CommandText = "INSERT INTO Libri(Nome, Autore, DataPubblicazione, Editore, IdCategoria) VALUES(@NOME,@AUTORE,@DATA_PUBBLICAZIONE,@EDITORE,@ID_CATEGORIA);";
	cmd.Parameters.AddWithValue("@NOME", "Inseguendo un raggio di luce");
	cmd.Parameters.AddWithValue("@AUTORE", "Amedeo Balbi");
	cmd.Parameters.AddWithValue("@DATA_PUBBLICAZIONE", "28/09/2021");
	cmd.Parameters.AddWithValue("@EDITORE", "Rizzoli");
	cmd.Parameters.AddWithValue("@ID_CATEGORIA", "4"); // Fisica
	cmd.ExecuteNonQuery();
}
*/

{
	var ctx = new MyDbContext();
	var libri = ctx.Libri.ToList();
}

/*
 * Vedere EntityFrameworkExample nel progetto del prof per le Query di filtro e i metodi add, edit e tutto il resto
 * Il prof usa la sintassi fluida
*/