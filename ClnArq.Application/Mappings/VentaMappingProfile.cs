using AutoMapper;
using ClnArq.Application.Dtos.Ventas;
using ClnArq.Domain.Entities;

namespace ClnArq.Application.Mappings;

public class VentaMappingProfile : Profile
{
    public VentaMappingProfile()
    {
        CreateMap<Venta, VentasDtoBase>()
            .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Fecha));

        CreateMap<Venta, VentasDtoGetAll>()
            .IncludeBase<Venta, VentasDtoBase>()   
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.PrecioUnico, opt => opt.MapFrom(src => src.ProductoPrecioUnitario))
            .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
            .ForMember(dest => dest.NombreCliente, opt => opt.MapFrom(src => src.ClienteNombre))
            .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
            .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.ProductoNombre))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Total));

        CreateMap<VentasDtoAdd, Venta>()
            .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
            .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
            .ForMember(dest => dest.Total, opt => opt.Ignore())
            .ForMember(dest => dest.ClienteNombre, opt => opt.Ignore())
            .ForMember(dest => dest.ProductoNombre, opt => opt.Ignore())
            .ForMember(dest => dest.ProductoPrecioUnitario, opt => opt.Ignore());

        CreateMap<VentasDtoUpdate, Venta>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
            .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.ProductoPrecioUnitario, opt => opt.MapFrom(src => src.PrecioUnico))
            .ForMember(dest => dest.ProductoNombre, opt => opt.MapFrom(src => src.NombreProducto))
            .ForMember(dest => dest.Total, opt => opt.Ignore())
            .ForMember(dest => dest.ClienteId, opt => opt.Ignore())
            .ForMember(dest => dest.ClienteNombre, opt => opt.Ignore())
            .ForMember(dest => dest.ProductoId, opt => opt.Ignore());
    }
}
