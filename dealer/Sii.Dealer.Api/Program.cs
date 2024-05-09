using Autofac;
using Autofac.Extensions.DependencyInjection;
using Configurator.Api;
using MassTransit;
using MediatR;
using Microsoft.OpenApi.Models;
using Serilog;
using Sii.Dealer.Api.HubConfig.Notification;
using Sii.Dealer.Api.Middleware;
using Sii.Dealer.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();

builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration, "Serilog")
    .CreateLogger();
builder.Logging.AddSerilog(logger);

builder.Services.AddSwaggerGen(config =>
{
    config.EnableAnnotations();
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Dealer API", Version = "v1" });
    config.SchemaFilter<SwaggerSchemaExampleFilter>();
});
builder.Services.AddScoped(
    sp => new ExceptionMiddleware(
        sp.GetRequiredService<ILogger<ExceptionMiddleware>>(),
        builder.Environment.IsDevelopment()
    )
);

builder.Services.AddHttpClient("Factory.Api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["FactoryApi:BaseAddress"]);
});

builder.Services.RegisterDealerOptions(builder.Configuration);
builder.Services.RegisterDealerDependencies();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DealerDependencyModule()));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

var scope = app.Services.GetAutofacRoot();
DealerStartup.EnsureDatabaseStructure(scope);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.MapHub<NotificationHub>("/notificationHub");

app.Run();
