using AutoMapper;
using Sii.CarOrder.Contracts.Factory;
using SiiCarOrder.Factory.Application.Functions.Commands.CreateFactoryOrder;
using SiiCarOrder.Factory.Application.Functions.Commands.UpdateStatusFactoryOrder;
using SiiCarOrder.Factory.Domain.Entities;
using SiiCarOrder.Factory.Dtos.DataTransferObjects;

namespace SiiCarOrder.Factory.Application.Mapping.MappingToDto
{
    public class MappingOrderedProduction : Profile
    {
        public MappingOrderedProduction()
        {
            CreateMap<OrderedProduction, OrderedProductionDto>()
                .ForMember(x => x.FactoryId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PlannedDeliveryDate, y => y.MapFrom(z => z.DeliveryDate));
            CreateMap<OrderedProduction, OrderedProductionFeedbackDto>();
            CreateMap<ProductionCanceledEvent, UpdateStatusFactoryOrderCommand>();
            CreateMap<ProductionEndedEvent, UpdateStatusFactoryOrderCommand>();
            CreateMap<OrderedProduction, CreateFactoryOrderCommand>()
                .ForMember(x => x.FactoryId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PlannedDeliveryDate, y => y.MapFrom(z => z.DeliveryDate));
            CreateMap<OrderedProductionProgressState, OrderedProductionProgressStateDto>();
        }
    }
}
