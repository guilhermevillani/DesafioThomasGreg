using DesafioTecnicoThomasGregAPI.Models.Models.DTOs;
using DesafioTecnicoThomasGregAPI.Repository.Interfaces;
using DesafioTecnicoThomasGregAPI.Services.Interfaces;

namespace DesafioTecnicoThomasGregAPI.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task GetAdressTypeId(IEnumerable<AddressDTO?>? addresses)
        {
            if (addresses is not null)
            {
                foreach (var address in addresses)
                {
                    var addressType = GetFirstWord(address.Name);
                    address.AddressTypeId = await _addressRepository.GetAddressTypeIdByName(addressType);
                }
            }

        }


        private string GetFirstWord(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Divide a string em palavras usando espaços como delimitador
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Retorna a primeira palavra (se houver)
            return words.Length > 0 ? words[0] : "Rua";
        }
    }
}
