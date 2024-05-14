using DesafioTecnicoThomasGregAPI.Data;
using DesafioTecnicoThomasGregAPI.Models.Models.DbModels;
using DesafioTecnicoThomasGregAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoThomasGregAPI.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly UserManager<IdentityUser> _userManager;

        public ClientsRepository(AppDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Client?>?> GetAllClientsByAdminIdAsync(string adminEmail)
        {
            var admin = await _userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                return default;
            }
            var result = _appDbContext.Clients
                        .Include(c => c.Addresses)
                        .Where(c => new Guid(admin.Id).Equals((c.AdminId)));
            return result;
        }

        public async Task<bool> AddClientByAdminId(string adminEmail, Client newClient)
        {
            var admin = await _userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                return false;
            }
            newClient.AdminId = new Guid(admin.Id);
            _appDbContext.Clients.Add(newClient);
            var result = await _appDbContext.SaveChangesAsync();
            return result > default(int);
        }
        public async Task<bool> UpdateClient(Client client)
        {
            _appDbContext.Clients.Update(client);
            var result = await _appDbContext.SaveChangesAsync();
            return result > default(int);
        }
        public async Task<bool> UpdateAdresses(Address address)
        {
            _appDbContext.Addresses.Update(address);
            var result = await _appDbContext.SaveChangesAsync();
            return result > default(int);
        }
    }
}
