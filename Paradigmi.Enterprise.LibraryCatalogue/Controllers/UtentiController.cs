using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Paradigmi.Enterprise.LibraryCatalogue.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class UtentiController : ControllerBase
	{
	}
}
