using Microsoft.AspNetCore.Identity;

namespace DesafioTecnicoThomasGregAPI.Services.Interfaces
{
    public interface IJwtManagementService
    {
        string GenerateJwtToken(IdentityUser user);
    }
}
