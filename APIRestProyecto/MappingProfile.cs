
using Entities.Models;
using Shared.DataTransferObjects;
using AutoMapper;

namespace APIRestProyecto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductoDTO>()
                .ForCtorParam("FullAddress",
                opt => opt.MapFrom(x => string.Join(' ', x.Nombre, x.Precio)));

            CreateMap<Stock, StockDTO>();

        }

    }
}

