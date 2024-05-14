using DesafioTecnicoThomasGregAPI.Data;
using DesafioTecnicoThomasGregAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoThomasGregAPI.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _appDbContext;
        public AddressRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> GetAddressTypeIdByName(string adressType)
        {
            var result = await _appDbContext.AddressTypes.FirstOrDefaultAsync(a => a.Type.Equals(adressType));
            return result?.Id ?? 1;
        }
    }
}
