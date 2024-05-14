
namespace DesafioTecnicoThomasGregAPI.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<int> GetAddressTypeIdByName(string adressType);
    }
}
