using System;
using AutoMapper;
using EventContract;
using Payment.Api.Commands;
using Payment.Api.Controllers;
using Payment.Domain;

namespace Payment.Api.ObjectMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentCreatedEvent, Domain.PaymentEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => PaymentStatus.PendingInvoice));
            CreateMap<CreatePaymentCommand, PaymentCreatedEvent>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<CreatePaymentRequestDto, CreatePaymentCommand>();
        }
    }
}