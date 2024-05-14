using AutoMapper;
using DesafioTecnicoThomasGregAPI.Facades.Interfaces;
using DesafioTecnicoThomasGregAPI.Models.Models.DbModels;
using DesafioTecnicoThomasGregAPI.Models.Models.DTOs;
using DesafioTecnicoThomasGregAPI.Repository.Interfaces;
using DesafioTecnicoThomasGregAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DesafioTecnicoThomasGregAPI.Facades
{
    public class ClientsFacade : IClientsFacade
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IClientsRepository _clientsRepository;
        private readonly IAddressService _adressService;

        private readonly IMapper _mapper;

        public ClientsFacade(UserManager<IdentityUser> userManager, IClientsRepository clientsRepository, IMapper mapper, IAddressService adressService)
        {
            _userManager = userManager;
            _clientsRepository = clientsRepository;
            _mapper = mapper;
            _adressService = adressService;
        }

        public async Task<IEnumerable<ClientDTO?>> GetClients(ClaimsPrincipal user)
        {
            var adminEmail = user.FindFirst(ClaimTypes.NameIdentifier);
            var clientsByAdmin = await _clientsRepository.GetAllClientsByAdminIdAsync(adminEmail.Value);

            var map = _mapper.Map<IEnumerable<ClientDTO>>(clientsByAdmin);

            return map;
        }

        public async Task<bool> AddClient(ClaimsPrincipal user, ClientDTO newClient)
        {
            var adminEmail = user.FindFirst(ClaimTypes.NameIdentifier);
            await _adressService.GetAdressTypeId(newClient.Addresses);
            var map = _mapper.Map<Client>(newClient);
            var result = await _clientsRepository.AddClientByAdminId(adminEmail.Value, map);

            return result;
        }
        public async Task<bool> UpdateClient(ClientDTO client)
        {
            var map = _mapper.Map<Client>(client);
            var result = await _clientsRepository.UpdateClient(map);
            return result;
        }

        public async Task<bool> UpdateAdresses(AddressDTO address)
        {
            var map = _mapper.Map<Address>(address);
            var result = await _clientsRepository.UpdateAdresses(map);

            return result;
        }
    }
}
