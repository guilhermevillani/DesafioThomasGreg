using DesafioTecnicoThomasGregAPI.Models.DTOs;

namespace DesafioTecnicoThomasGregAPI.Facades.Interfaces
{
    public interface IAuthManagementFacade
    {
        Task<LoginRequestResponse> LoginUser(UserLoginRequestDto userLoginRequestDto);
        Task<RegistrarionRequestResponse> RegisterUser(UserRegistrationRequestDto registrationRequestDto);
    }
}
