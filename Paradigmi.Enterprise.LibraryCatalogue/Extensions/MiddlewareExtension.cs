namespace Paradigmi.Enterprise.LibraryCatalogue.Extensions
{
	public static class MiddlewareExtension
	{
		public static WebApplication? AddWebMiddleware(this WebApplication? app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			return app;
		}
	}
}
