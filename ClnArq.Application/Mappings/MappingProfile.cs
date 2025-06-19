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
            .ForMember(dest => dest.Cantidad,
                       opt => opt.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.Date,
                       opt => opt.MapFrom(src => src.Fecha))
            .ForMember(dest => dest.TotalAmount,
                       opt => opt.MapFrom(src => src.Total))
            .ForMember(dest => dest.ClienteId,
                       opt => opt.MapFrom(src => src.ClienteId))
            .ForMember(dest => dest.NombreCliente,
                       opt => opt.MapFrom(src => src.ClienteNombre))
            .ForMember(dest => dest.ProductoId,
                       opt => opt.MapFrom(src => src.ProductoId))
            .ForMember(dest => dest.NombreProducto,
                       opt => opt.MapFrom(src => src.ProductoNombre))
            .ForMember(dest => dest.PrecioUnico,
                       opt => opt.MapFrom(src => src.ProductoPrecioUnitario));


        CreateMap<VentaDto, Venta>()
            .ForMember(dest => dest.Id,
                       opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Cantidad,
                       opt => opt.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.Fecha,
                       opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Total,
                       opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.ClienteId,
                       opt => opt.MapFrom(src => src.ClienteId))
            .ForMember(dest => dest.ClienteNombre,
                       opt => opt.MapFrom(src => src.NombreCliente))
            .ForMember(dest => dest.ProductoId,
                       opt => opt.MapFrom(src => src.ProductoId))
            .ForMember(dest => dest.ProductoNombre,
                       opt => opt.MapFrom(src => src.NombreProducto))
            .ForMember(dest => dest.ProductoPrecioUnitario,
                       opt => opt.MapFrom(src => src.PrecioUnico));

    }
}
