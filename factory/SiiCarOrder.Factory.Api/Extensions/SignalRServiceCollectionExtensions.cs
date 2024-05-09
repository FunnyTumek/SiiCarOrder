namespace SiiCarOrder.Factory.Api.Extensions
{
    public static class SignalRServiceCollectionExtensions
    {
        public static IServiceCollection AddSignalRService(this IServiceCollection services)
        {
            services.AddSignalR(cfg => cfg.EnableDetailedErrors = true);
            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(hosts => true));
            }
            );

            return services;
        }
    }
}
