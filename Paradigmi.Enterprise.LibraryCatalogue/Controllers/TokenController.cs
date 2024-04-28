using Microsoft.AspNetCore.Mvc;
using Paradigmi.Enterprise.Application.Abstractions.Services;
using Paradigmi.Enterprise.Application.Models.Requests;
using Paradigmi.Enterprise.Application.Models.Responses;

namespace Paradigmi.Enterprise.LibraryCatalogue.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class TokenController : Controller
	{
		private readonly ITokenService _tokenService;

		public TokenController(ITokenService tokenService)
		{
			_tokenService = tokenService;
		}

		[HttpPost]
		[Route("create")]
		public IActionResult Create(CreateTokenRequest request)
		{

			string token = _tokenService.CreateToken(request);
			return Ok(new CreateTokenResponse(token));
		}
	}
}
