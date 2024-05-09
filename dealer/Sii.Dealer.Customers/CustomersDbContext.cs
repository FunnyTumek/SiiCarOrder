using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sii.Dealer.Customers.Entities;
using Sii.Dealer.Customers.Mapping;

namespace Sii.Dealer.Customers
{
    public class CustomersDbContext : DbContext
    {
        private const string MIGRATIONS_HISTORY_TABLE = "__CustomersMigrationsHistory";
        public const string SCHEMA_NAME = "customers";
        private readonly ILoggerFactory loggerFactory;

        public string ConnectionString { get; }

        public CustomersDbContext(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("CustomersDbContext");
        }

        public CustomersDbContext(IConfiguration configuration, DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            this.loggerFactory = loggerFactory;
            ConnectionString = configuration.GetConnectionString("CustomersDbContext");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString, x => x.MigrationsHistoryTable(MIGRATIONS_HISTORY_TABLE));
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(SCHEMA_NAME);
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
