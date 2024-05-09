﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sii.Dealer.Core.Infrastructure.Data;

#nullable disable

namespace Sii.Dealer.Core.Infrastructure.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    [Migration("20220712091233_OrderDetailListViewEdit")]
    partial class OrderDetailListViewEdit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sales")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.AdditionalEquipment", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("AdditionalEquipment", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.AdditionalEquipmentSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalEquipmentCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CarConfigurationId")
                        .HasColumnType("int");

                    b.Property<int?>("CarConfigurationId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalEquipmentCode");

                    b.HasIndex("CarConfigurationId")
                        .IsUnique();

                    b.HasIndex("CarConfigurationId1");

                    b.ToTable("AdditionalEquipmentSet", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Brand", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Brands", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.CarClass", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("CarClass", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.CarConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrandCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarClassCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ColorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EngineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EquipmentVersionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GearboxCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InteriorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModelCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandCode");

                    b.HasIndex("CarClassCode");

                    b.HasIndex("ColorCode");

                    b.HasIndex("EngineCode");

                    b.HasIndex("EquipmentVersionCode");

                    b.HasIndex("GearboxCode");

                    b.HasIndex("InteriorCode");

                    b.HasIndex("ModelCode");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("CarConfiguration", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Color", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Colors", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Engine", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("Engine", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.EquipmentVersion", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("EquipmentVersion", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Gearbox", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("GearsCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("Gearbox", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Interior", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Interiors", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Model", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("CarModel", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("money");

                    b.Property<DateTime?>("PlannedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.OrderComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderComments", "sales");
                });

            modelBuilder.Entity("Sii.Dealer.SharedKernel.Sales.ViewModels.OrderDetailViewModel", b =>
                {
                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EngineCapacity")
                        .HasColumnType("int");

                    b.Property<int>("EnginePower")
                        .HasColumnType("int");

                    b.Property<int>("EngineType")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GearboxCount")
                        .HasColumnType("int");

                    b.Property<int>("GearboxType")
                        .HasColumnType("int");

                    b.Property<string>("Interior")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.ToView("OrderDetailListView");
                });

            modelBuilder.Entity("Sii.Dealer.SharedKernel.Sales.ViewModels.OrderListViewModel", b =>
                {
                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.ToView("OrderListView");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.AdditionalEquipmentSet", b =>
                {
                    b.HasOne("Sii.Dealer.Core.Domain.Entities.AdditionalEquipment", "AdditionalEquipment")
                        .WithMany("AdditionalEquipmentSet")
                        .HasForeignKey("AdditionalEquipmentCode");

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.CarConfiguration", null)
                        .WithOne("AdditionalEquipmentSet")
                        .HasForeignKey("Sii.Dealer.Core.Domain.Entities.AdditionalEquipmentSet", "CarConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.CarConfiguration", "CarConfiguration")
                        .WithMany()
                        .HasForeignKey("CarConfigurationId1");

                    b.Navigation("AdditionalEquipment");

                    b.Navigation("CarConfiguration");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.CarConfiguration", b =>
                {
                    b.HasOne("Sii.Dealer.Core.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.CarClass", "CarClass")
                        .WithMany()
                        .HasForeignKey("CarClassCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.EquipmentVersion", "EquipmentVersion")
                        .WithMany()
                        .HasForeignKey("EquipmentVersionCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.Gearbox", "Gearbox")
                        .WithMany()
                        .HasForeignKey("GearboxCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.Interior", "Interior")
                        .WithMany()
                        .HasForeignKey("InteriorCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sii.Dealer.Core.Domain.Entities.Order", "Order")
                        .WithOne("Configuration")
                        .HasForeignKey("Sii.Dealer.Core.Domain.Entities.CarConfiguration", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("CarClass");

                    b.Navigation("Color");

                    b.Navigation("Engine");

                    b.Navigation("EquipmentVersion");

                    b.Navigation("Gearbox");

                    b.Navigation("Interior");

                    b.Navigation("Model");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Order", b =>
                {
                    b.OwnsOne("Sii.Dealer.Core.Domain.ValueObjects.Customer", "Customer", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "sales");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.OrderComment", b =>
                {
                    b.HasOne("Sii.Dealer.Core.Domain.Entities.Order", "Order")
                        .WithMany("Comments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.AdditionalEquipment", b =>
                {
                    b.Navigation("AdditionalEquipmentSet");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.CarConfiguration", b =>
                {
                    b.Navigation("AdditionalEquipmentSet");
                });

            modelBuilder.Entity("Sii.Dealer.Core.Domain.Entities.Order", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Configuration");
                });
#pragma warning restore 612, 618
        }
    }
}
