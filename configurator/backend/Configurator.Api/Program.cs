using Configurator.Api;
using Configurator.Api.Application;
using Configurator.Api.Application.Services;
using Configurator.Api.Application.Services.Implementations;
using Configurator.Api.DataAccess;
using Configurator.Api.DataAccess.Data;
using Configurator.Api.DataAccess.Data.Implementations;
using Configurator.Api.Dtos.Contracts;
using Configurator.Api.Consumers;
using Configurator.Api.Extensions;
using Configurator.Api.Hubs;
using Configurator.Api.Middleware;
using Configurator.Api.Validators;
using FluentValidation;
using MassTransit;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration, "Serilog")
	.CreateLogger();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
	config.EnableAnnotations();
	config.SwaggerDoc("v1", new OpenApiInfo { Title = "Configurator API", Version = "v1" });
	config.SchemaFilter<SwaggerSchemaExampleFilter>();
});

builder.Services.AddAutoMapper(config =>
{
	config.AddProfile<MappingProfile>();
});

builder.Services
	.AddOptions<ConfigurationsDatabaseSettings>()
	.Bind(builder.Configuration.GetSection("ConfigurationsDatabase"))
	.ValidateDataAnnotations()
	.ValidateOnStart();
builder.Services
	.AddOptions<DefaultCarConfigurationSettings>()
	.Bind(builder.Configuration.GetSection("DefaultConfiguration"))
	.ValidateDataAnnotations()
	.ValidateOnStart();
builder.Services
	.AddOptions<RedisSettings>()
	.Bind(builder.Configuration.GetSection("Redis"))
	.ValidateDataAnnotations()
	.ValidateOnStart();
builder.Services.AddSingleton<IConfigurationsDbContext, ConfigurationsDbContext>();

builder.Services.AddScoped<IAvailableConfigurationsService, AvailableConfigurationsService>();
builder.Services.AddScoped<ISavedConfigurationsService, SavedConfigurationsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IDefaultConfigurationsService, DefaultConfigurationsService>();
builder.Services.AddScoped<ICacheService, RedisCacheService>();
builder.Services.AddScoped<ICachedDtoRetrievalService, CachedDtoRetrievalService>();
builder.Services.AddScoped<IJsonFileService, JsonFileService>();

builder.Services.AddScoped<IValidator<CarConfigurationBaseDto>, ConfigurationValidator>();


builder.Services.AddHttpClient("Dealer.Api", client =>
{
	client.BaseAddress = new Uri(builder.Configuration["DealerApi:BaseAddress"]);
});

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); //TODO: Change CORS policy
	});
});

builder.Services.AddScoped(
	sp => new ExceptionMiddleware(
		sp.GetRequiredService<ILogger<ExceptionMiddleware>>(),
		builder.Environment.IsDevelopment()
	)
);

var multiplexer = ConnectionMultiplexer.Connect(
	builder.Configuration["Redis:ConfigurationString"]
);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

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

	x.AddConsumer<NotificationConsumer>();
});

builder.Services.AddSignalRService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
	endpoints.MapHub<ConfiguratorHub>("/notifications");
});

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

try
{
	app.Run();
}
catch (OptionsValidationException e)
{
	foreach (var failure in e.Failures)
	{
		logger.Fatal(failure);
	}
	Environment.Exit(1);
}
