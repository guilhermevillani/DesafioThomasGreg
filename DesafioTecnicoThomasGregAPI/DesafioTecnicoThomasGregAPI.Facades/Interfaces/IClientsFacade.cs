using DesafioTecnicoThomasGregAPI.Models.Models.DTOs;
using System.Security.Claims;

namespace DesafioTecnicoThomasGregAPI.Facades.Interfaces
{
    public interface IClientsFacade
    {
        Task<bool> AddClient(ClaimsPrincipal user, ClientDTO newClient);
        Task<IEnumerable<ClientDTO?>> GetClients(ClaimsPrincipal user);
        Task<bool> UpdateAdresses(AddressDTO address);
        Task<bool> UpdateClient(ClientDTO client);
    }
}
