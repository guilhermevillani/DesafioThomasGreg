
using DesafioTecnicoThomasGregAPI.Models.Models.DTOs;

namespace DesafioTecnicoThomasGregAPI.Services.Interfaces
{
    public interface IAddressService
    {
        Task GetAdressTypeId(IEnumerable<AddressDTO?>? addresses);
    }
}
