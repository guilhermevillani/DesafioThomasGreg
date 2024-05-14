using DesafioTecnicoThomasGregAPI.Facades.Interfaces;
using DesafioTecnicoThomasGregAPI.Models.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoThomasGregAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientsController : Controller
    {
        public readonly IClientsFacade _clientsFacade;
        public ClientsController(IClientsFacade clientsFacade)
        {
            _clientsFacade = clientsFacade;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Get()
        {
            var result = await _clientsFacade.GetClients(this.User);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientDTO newClient)
        {
            if (ModelState.IsValid)
            {
                var result = await _clientsFacade.AddClient(this.User, newClient);

                return result ? CreatedAtAction(nameof(Post), newClient) : BadRequest();

            }
            return BadRequest(ModelState + "Is not a valid request payload");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateClient([FromBody] ClientDTO client)
        {
            if (ModelState.IsValid)
            {
                var result = await _clientsFacade.UpdateClient(client);

                return result ? Ok() : BadRequest();

            }
            return BadRequest(ModelState + "Is not a valid request payload");
        }

        [HttpPatch]
        [Route("/UpdateAdresses")]
        public async Task<IActionResult> UpdateAdresses([FromBody] AddressDTO address)
        {
            if (ModelState.IsValid)
            {
                var result = await _clientsFacade.UpdateAdresses(address);

                return result ? Ok() : BadRequest();

            }
            return BadRequest(ModelState + "Is not a valid request payload");
        }
        //[HttpDelete]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _authManagementFacade.LoginUser(userLoginRequestDto);

        //        return result.Result ? Ok(result) : BadRequest(result.Erros);

        //    }
        //    return BadRequest(ModelState + "Is not a valid request payload");
        //}
    }
}
