using AutoMapper;
using EventContract;
using Product.Api.Commands;
using Product.Domain;

namespace Product.Api.ObjectMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateProductCommand, ProductUpdatedEvent>();
            CreateMap<InvoiceDetailDto, ProductEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}