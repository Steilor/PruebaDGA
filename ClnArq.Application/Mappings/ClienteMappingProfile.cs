using AutoMapper;
using ClnArq.Application.Dtos.Clientes;
using ClnArq.Domain.Entities;

namespace ClnArq.Application.Mappings;

public class ClienteMappingProfile : Profile
{
    public ClienteMappingProfile()
    {
        CreateMap<Cliente, ClientesDtoGetAll>()
            .ForMember(dest => dest.Id,
                       opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Creado,
                       opt => opt.MapFrom(src => src.Creado));

        CreateMap<Cliente, ClientesDtoBase>();

        CreateMap<Cliente, ClientesDtoRemove>()
            .ForMember(dest => dest.ClienteId,
                       opt => opt.MapFrom(src => src.Id))

            .ForMember(dest => dest.Eliminado,
                       opt => opt.MapFrom(_ => true));


        CreateMap<ClientesDtoAdd, Cliente>();

        CreateMap<ClientesDtoUpdate, Cliente>()
            .ForMember(dest => dest.Id,
                       opt => opt.MapFrom(src => src.Id));
    }
}
