using Autofac;
using Sii.Dealer.Customers;
using Sii.Dealer.Core.Application.Services;
using Sii.Dealer.Core.Domain;
using Sii.Dealer.Core.Domain.Repositories;
using Sii.Dealer.Core.Domain.Services;
using Sii.Dealer.Core.Infrastructure;
using Sii.Dealer.Core.Infrastructure.Repositories;
using Sii.Dealer.Core.Infrastructure.Services.Application;
using Sii.Dealer.Core.Infrastructure.Services.Domain;
using Sii.Dealer.Core.Infrastructure.Data;
using AutoMapper;
using Sii.Dealer.Core.Infrastructure.Mappings;
using Sii.Dealer.Core.Application.Services.ConfiguratorServices;
using Sii.Dealer.Core.Infrastructure.Services.Application.ConfuguratorServices;
using Sii.Dealer.Customers.Services.Implementations;
using Sii.Dealer.Customers.Services;
using Sii.Dealer.Customers.Mapping.MappingToDto;
using Sii.Dealer.Customers.Consumers;
using Sii.Dealer.Core.Infrastructure.Services.Infrastructure;
using Sii.Dealer.Core.Application.Services.Infrastructure;
using Sii.Dealer.ReadModel.Dealer.Implementation;
using Sii.Dealer.ReadModel.Dealer;

namespace Sii.Dealer.DependencyInjection
{
    public class DealerDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<OrdersApplicationService>().As<IOrdersApplicationService>();
            builder.RegisterType<FactoryService>().As<IFactoryService>();
            builder.RegisterType<CustomersService>().As<ICustomersService>();
            builder.RegisterType<BrandService>().As<IBrandService>();
            builder.RegisterType<CarClassService>().As<ICarClassService>();
            builder.RegisterType<ColorService>().As<IColorService>();
            builder.RegisterType<EngineService>().As<IEngineService>();
            builder.RegisterType<EquipmentVersionService>().As<IEquipmentVersionService>();
            builder.RegisterType<GearboxService>().As<IGearboxService>();
            builder.RegisterType<InteriorService>().As<IInteriorService>();
            builder.RegisterType<ModelService>().As<IModelService>();
            builder.RegisterType<AdditionalEquipmentService>().As<IAdditionalEquipmentService>();
            builder.RegisterType<PriceCalculationService>().As<IPriceCalculationService>();
            builder.RegisterType<OrdersRepository>().As<IOrdersRepository>();
            builder.RegisterType<OrdersQuery>().As<IOrdersQuery>();
            builder.RegisterType<ConfiguratorOptionsRepository>().As<IConfigurationOptionsRepository>();
            builder.RegisterType<PdfService>().As<IPdfService>();
            builder.RegisterType<SalesUnitOfWork>().As<ISalesUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<SalesDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomersDbContext>().AsSelf().InstancePerDependency();
            builder.RegisterType<AvailableConfigurationsService>().As<IAvailableConfigurationsService>();
            builder.RegisterType<AvailableConfigurationsRepository>().As<IAvailableConfigurationsRepository>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                cfg.AddProfile<MappingCustomersProfile>();

            })).AsSelf().SingleInstance();
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}