using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sii.CarOrder.Contracts.Enums;
using SiiCarOrder.Factory.Domain.Entities;

namespace SiiCarOrder.Factory.Infrastructure.Persistance

{
    public class FactoryDbContext : DbContext
    {
        private const string MIGRATIONS_HISTORY_TABLE = "__FactoryMigrationsHistory";
        public const string SCHEMA_NAME = "factory";

        public string ConnectionString { get; }

        public FactoryDbContext(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("FactoryDbContext");
        }

        public FactoryDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            ConnectionString = configuration.GetConnectionString("FactoryDbContext");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString, x => x.MigrationsHistoryTable(MIGRATIONS_HISTORY_TABLE));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(SCHEMA_NAME);
            modelBuilder.ApplyConfiguration(new OrderedProductionMap());
            modelBuilder.ApplyConfiguration(new OrderedProductionProgressStateMap());

            modelBuilder.Entity<OrderedProductionProgressState>()
                .HasOne<OrderedProduction>(x => x.Production)
                .WithMany(x => x.ProgressStates)
                .HasForeignKey(x => x.ProductionId);
        }

        public bool ApplyPendingMigrations()
        {
            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
                return true;
            }
            return false;
        }

        public DbSet<OrderedProduction> OrderedProductions { get; set; }
        public DbSet<OrderedProductionProgressState> OrderedProductionsProgressStates { get; set; }
    }
}
