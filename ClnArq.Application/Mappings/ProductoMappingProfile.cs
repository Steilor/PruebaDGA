using AutoMapper;
using ClnArq.Application.Dtos.Productos;
using ClnArq.Domain.Entities;

namespace ClnArq.Application.Mappings;

public class ProductoMappingProfile : Profile
{
	public ProductoMappingProfile()
	{
        CreateMap<Producto, ProductosDtoGetAll>()
            .ForMember(dest => dest.Id,
                       opt => opt.MapFrom(src => src.Id));

        CreateMap<Producto, ProductosDtoBase>();

        CreateMap<Producto, ProductosDtoRemove>()
            .ForMember(dest => dest.ProductoId,
                       opt => opt.MapFrom(src => src.Id))

            .ForMember(dest => dest.Eliminado,
                       opt => opt.MapFrom(_ => true));

        CreateMap<ProductosDtoAdd, Producto>();

        CreateMap<ProductosDtoUpdate, Producto>()
            .ForMember(dest => dest.Id,
                       opt => opt.MapFrom(src => src.Id));
    }
}
