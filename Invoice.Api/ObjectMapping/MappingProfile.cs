using AutoMapper;
using EventContract;
using Invoice.Api.Commands;
using Invoice.Domain;

namespace Invoice.Api.ObjectMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentCreatedEvent, CreateInvoiceCommand>();
            CreateMap<CreateInvoiceCommand, InvoiceCreatedEvent>();
            CreateMap<InvoiceDetailDto, InvoiceDetailEntity>().ReverseMap();
        }
    }
}