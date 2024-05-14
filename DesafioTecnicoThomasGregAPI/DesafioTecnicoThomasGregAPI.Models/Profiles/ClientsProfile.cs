using AutoMapper;
using DesafioTecnicoThomasGregAPI.Models.Models.DbModels;
using DesafioTecnicoThomasGregAPI.Models.Models.DTOs;

namespace DesafioTecnicoThomasGregAPI.Models.Profiles
{
    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            // Source -> Target
            CreateMap<Client, ClientDTO>()
           .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));

            CreateMap<Address, AddressDTO>();

            CreateMap<ClientDTO, Client>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.AdminId, opt => opt.Ignore()); // Ignorando a atribuição de AdminId, já que não está em ClientDTO

            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();

        }

    }
}
