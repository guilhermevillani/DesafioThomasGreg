using DesafioTecnicoThomasGregAPI.Models.Models.DbModels;

namespace DesafioTecnicoThomasGregAPI.Repository.Interfaces
{
    public interface IClientsRepository
    {
        Task<bool> AddClientByAdminId(string adminEmail, Client newClient);
        Task<IEnumerable<Client?>> GetAllClientsByAdminIdAsync(string adminEmail);
        Task<bool> UpdateAdresses(Address address);
        Task<bool> UpdateClient(Client client);
    }
}
