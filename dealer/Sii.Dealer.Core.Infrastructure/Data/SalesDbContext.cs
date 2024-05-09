using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Entities.CarConfigurationEntities;
using Sii.Dealer.Core.Infrastructure.Mappings;
using Sii.Dealer.SharedKernel.Sales.ViewModels;

namespace Sii.Dealer.Core.Infrastructure.Data
{
    public class SalesDbContext : DbContext
    {
        private const string MIGRATIONS_HISTORY_TABLE = "__SalesMigrationsHistory";
        internal const string DB_MONEY_TYPE = "money";
        public const string SCHEMA_NAME = "sales";
        private readonly ILoggerFactory loggerFactory;

        public string ConnectionString { get; }

        public SalesDbContext(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("SalesDbContext");
        }

        public SalesDbContext(IConfiguration configuration, DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
        {
            ConnectionString = configuration.GetConnectionString("SalesDbContext");
            this.loggerFactory = loggerFactory;
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

            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderCommentMap());

            modelBuilder.ApplyConfiguration(new ConfigurationMap());
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new ModelMap());
            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new CarClassMap());
            modelBuilder.ApplyConfiguration(new EngineMap());
            modelBuilder.ApplyConfiguration(new EquipmentVersionMap());
            modelBuilder.ApplyConfiguration(new GearboxMap());
            modelBuilder.ApplyConfiguration(new InteriorMap());
            modelBuilder.ApplyConfiguration(new AdditionalEquipmentMap());
            modelBuilder.ApplyConfiguration(new AdditionalEquipmentsSetMap());
            modelBuilder.ApplyConfiguration(new OrderListViewModelMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
            modelBuilder.ApplyConfiguration(new AvailableCarConfigurationMap());

            modelBuilder.Entity<OrderDetailViewModel>(e =>
            {
                e.HasNoKey();
                e.ToView("OrderDetailListView");            
            });

			modelBuilder.Entity<PdfDetailViewModel>(e =>
			{
				e.HasNoKey();
				e.ToView("PdfDetailView");
			});
			modelBuilder.Entity<AvailableConfigurationAdditionalEquipment>()
                .HasKey(acae => new { acae.AvailableConfigurationId, acae.EquipmentCode });
            modelBuilder.Entity<AvailableConfigurationAdditionalEquipment>()
                .HasOne(acae => acae.AvailableCarConfiguration)
                .WithMany(acae => acae.ConfigurationAdditionalEquipments)
                .HasForeignKey(acae => acae.AvailableConfigurationId);
            modelBuilder.Entity<AvailableConfigurationAdditionalEquipment>()
                .HasOne(acae => acae.AdditionalEquipment)
                .WithMany(acae => acae.ConfigurationAdditionalEquipments)
                .HasForeignKey(acae => acae.EquipmentCode);
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderComment> OrderComments { get; set; }

        public DbSet<OrderListViewModel> OrderListView { get; set; }

        public DbSet<OrderDetailViewModel> OrderDetailListView { get; set; }
        public DbSet<PdfDetailViewModel> PdfDetailViewModel { get; set; }

        public DbSet<AvailableCarConfiguration> AvailableConfigurations { get; set; }

        public DbSet<AvailableConfigurationAdditionalEquipment> AvailableConfigurationAdditionalEquipment { get; set; }
    }
}
