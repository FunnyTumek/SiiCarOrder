using MassTransit;
using MediatR;
using Microsoft.OpenApi.Models;
using Serilog;
using SiiCarOrder.Factory.Application.Service;
using SiiCarOrder.Factory.Application.Service.Implementations;
using SiiCarOrder.Factory.Scheduler.Extensions;
using SiiCarOrder.Factory.Api.Consumers;
using SiiCarOrder.Factory.Scheduler.Hubs;
using SiiCarOrder.Factory.Api.Extensions;
using SiiCarOrder.Factory.Scheduler.Models;
using SiiCarOrder.Factory.Application.Mapping.MappingToDto;
using SiiCarOrder.Factory.Infrastructure.Persistance;
using SiiCarOrder.Factory.Infrastructure.Repositories;
using SiiCarOrder.Factory.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration, "Serilog")
    .CreateLogger();
builder.Logging.AddSerilog(logger);

builder.Services.AddSwaggerGen(config =>
{
    config.EnableAnnotations();
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Factory API", Version = "v1" });
});

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MappingOrderedProduction>();
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var hostName = builder.Configuration["RabbitMQ:RabbitMqHost"];
var userName = builder.Configuration["RabbitMQ:RabbitMqUser"];
var password = builder.Configuration["RabbitMQ:RabbitMqPassword"];
var virutalHost = builder.Configuration["RabbitMQ:RabbitMqVirtualHost"];

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(hostName, virutalHost, h =>
        {
            h.Username(userName);
            h.Password(password);
        });
        cfg.ConfigureEndpoints(context);
    });

    x.AddConsumer<CarProductionStartedConsumer>(typeof(CarProductionStartedConsumerDefinition));
    x.AddConsumer<CarProductionCanceledConsumer>();
    x.AddConsumer<CarProductionEndedConsumer>();
    x.AddConsumer<CollectOrderConsumer>();
});

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<FactoryDbContext>();

builder.Services.AddScoped<IFactoryOrderService, FactoryOrderService>();
builder.Services.AddScoped<IOrderedProductionRepository, OrderedProductionRepository>();

builder.Services.AddQuartzScheduler();

builder.Services.AddTimerManager();

builder.Services.AddSignalRService();

builder.Services.AddOptions<ProductionParams>()
                .Bind(builder.Configuration.GetSection(nameof(ProductionParams)))
                .ValidateDataAnnotations()
                .ValidateOnStart();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ProductionProgressHub>("/productionProgressNotifications");
});

app.MapControllers();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FactoryDbContext>();
    context.ApplyPendingMigrations();
}

app.Run();
