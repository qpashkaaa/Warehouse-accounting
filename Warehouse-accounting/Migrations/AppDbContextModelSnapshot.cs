﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Warehouse_accounting.Data;

#nullable disable

namespace Warehouse_accounting.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.AccessLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AccessLevel");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.AuthorizationData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessLevelId")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccessLevelId");

                    b.ToTable("AuthorizationDatas");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeePositionId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Unique_number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WorkGroupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeePositionId");

                    b.HasIndex("EmployeeStatusId");

                    b.HasIndex("WorkGroupId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmployeePosition");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.EmployeeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmployeeStatus");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UniqueNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WarehouseAddressId")
                        .HasColumnType("integer");

                    b.Property<int>("WarehouseStatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseAddressId");

                    b.HasIndex("WarehouseStatusId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WarehouseAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WarehouseAddress");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WarehouseLoading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LoadingPercent")
                        .HasColumnType("integer");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseLoading");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WarehouseStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WarehouseStatus");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WorkGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WorkGroup");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.AuthorizationData", b =>
                {
                    b.HasOne("Warehouse_accounting.Model.DbModels.AccessLevel", "AccessLevel")
                        .WithMany("AuthorizationDatas")
                        .HasForeignKey("AccessLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessLevel");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.Employee", b =>
                {
                    b.HasOne("Warehouse_accounting.Model.DbModels.EmployeePosition", "EmployeePosition")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeePositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_accounting.Model.DbModels.EmployeeStatus", "EmployeeStatus")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_accounting.Model.DbModels.WorkGroup", "WorkGroup")
                        .WithMany("Employees")
                        .HasForeignKey("WorkGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeePosition");

                    b.Navigation("EmployeeStatus");

                    b.Navigation("WorkGroup");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.Warehouse", b =>
                {
                    b.HasOne("Warehouse_accounting.Model.DbModels.WarehouseAddress", "WarehouseAddress")
                        .WithMany("Warehouses")
                        .HasForeignKey("WarehouseAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse_accounting.Model.DbModels.WarehouseStatus", "WarehouseStatus")
                        .WithMany("Warehouses")
                        .HasForeignKey("WarehouseStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WarehouseAddress");

                    b.Navigation("WarehouseStatus");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WarehouseLoading", b =>
                {
                    b.HasOne("Warehouse_accounting.Model.DbModels.Warehouse", "Warehouse")
                        .WithMany("WarehouseLoadings")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WorkGroup", b =>
                {
                    b.HasOne("Warehouse_accounting.Model.DbModels.Warehouse", "Warehouse")
                        .WithMany("WorkGroups")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.AccessLevel", b =>
                {
                    b.Navigation("AuthorizationDatas");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.EmployeePosition", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.EmployeeStatus", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.Warehouse", b =>
                {
                    b.Navigation("WarehouseLoadings");

                    b.Navigation("WorkGroups");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WarehouseAddress", b =>
                {
                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WarehouseStatus", b =>
                {
                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("Warehouse_accounting.Model.DbModels.WorkGroup", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
