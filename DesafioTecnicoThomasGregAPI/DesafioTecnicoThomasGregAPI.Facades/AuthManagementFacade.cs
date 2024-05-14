using DesafioTecnicoThomasGregAPI.Facades.Interfaces;
using DesafioTecnicoThomasGregAPI.Models.DTOs;
using DesafioTecnicoThomasGregAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DesafioTecnicoThomasGregAPI.Facades
{
    public class AuthManagementFacade : IAuthManagementFacade
    {
        private readonly IJwtManagementService _jwtManagementService;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthManagementFacade(UserManager<IdentityUser> userManager, IJwtManagementService jwtManagementService)
        {
            _userManager = userManager;
            _jwtManagementService = jwtManagementService;
        }

        public async Task<LoginRequestResponse> LoginUser(UserLoginRequestDto userLoginRequestDto)
        {
            var emailExists = await _userManager.FindByEmailAsync(userLoginRequestDto.Email);
            if (emailExists is not null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(emailExists, userLoginRequestDto.Password);
                if (isPasswordValid)
                {
                    var token = _jwtManagementService.GenerateJwtToken(emailExists);
                    return new LoginRequestResponse()
                    {
                        Token = token,
                        Result = true
                    };
                }
            }

            return new LoginRequestResponse()
            {
                Result = false,
                Erros = ["Invalid User"]
            };
        }

        public async Task<RegistrarionRequestResponse> RegisterUser(UserRegistrationRequestDto registrationRequestDto)
        {
            var newUser = new IdentityUser { Email = registrationRequestDto.Email, UserName = registrationRequestDto.Email };
            var isCreated = await _userManager.CreateAsync(newUser, registrationRequestDto.Password);

            if (isCreated.Succeeded)
            {
                return new RegistrarionRequestResponse()
                {
                    Result = true,
                    Token = _jwtManagementService.GenerateJwtToken(newUser)
                };
            }
            return new RegistrarionRequestResponse()
            {
                Result = false,
                Erros = isCreated.Errors.Select(x => x.Description).ToList()
            };
        }
    }
}
