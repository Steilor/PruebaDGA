using AutoMapper;
using ClnArq.Application.Dtos;
using ClnArq.Domain.Entities;

namespace ClnArq.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
       
        CreateMap<Cliente, ClienteDto>()
            .ReverseMap();

      
        CreateMap<Producto, ProductoDto>()
            .ReverseMap();

        CreateMap<Venta, VentaDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ClientId,
                opt => opt.MapFrom(src => src.ClienteId))
            .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.Fecha))
            .ForMember(dest => dest.TotalAmount,
                opt => opt.MapFrom(src => src.Total))
            .ReverseMap();
    }
}
