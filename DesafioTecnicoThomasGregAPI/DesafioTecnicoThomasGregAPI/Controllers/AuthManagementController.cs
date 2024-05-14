using DesafioTecnicoThomasGregAPI.Facades.Interfaces;
using DesafioTecnicoThomasGregAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoThomasGregAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AuthManagementController : ControllerBase
	{
		private readonly IAuthManagementFacade _authManagementFacade;

		public AuthManagementController(IAuthManagementFacade authManagementFacade)
		{
			_authManagementFacade = authManagementFacade;
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto)
		{
			if (ModelState.IsValid)
			{
				var result = await _authManagementFacade.LoginUser(userLoginRequestDto);

				return result.Result ? Ok(result) : BadRequest(result.Erros);

			}
			return BadRequest(ModelState + "Is not a valid request payload");
		}

		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto registrationRequestDto)
		{
			if (ModelState.IsValid)
			{
				var result = await _authManagementFacade.RegisterUser(registrationRequestDto);

				return result.Result ? Ok(result) : BadRequest(result.Erros);
			}
			return BadRequest(ModelState + "Is not a valid request payload");
		}

	}
}
