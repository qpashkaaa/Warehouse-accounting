using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using Warehouse_accounting.Model.DbModels;

namespace Warehouse_accounting.Data
{
    public class AppDbContext : DbContext
    {
        #region AUTH_TABLES
        public DbSet<AuthorizationData> AuthorizationDatas { get; set; }
        public DbSet<AccessLevel> AccessLevels { get; set; }
        #endregion

        #region WAREHOUSES_TABLES
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseAddress> WarehouseAddresses { get; set; }
        public DbSet<WarehouseLoading> WarehouseLoadings { get; set; }
        public DbSet<WarehouseStatus> WarehouseStatuses { get; set; }

        #endregion

        #region EMPLOYEE_TABLES
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<WorkGroup> WorkGroups { get; set; }
        #endregion

        public AppDbContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfiguration configuration;
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();
            // connect to postgres with connection string from app settings
            options.UseNpgsql(configuration.GetSection("WPFDatabase").Value);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region AccessLevelDefaultData
            modelBuilder.Entity<AccessLevel>().HasData(
                     new AccessLevel { Id = 1, Level = "Администратор" },
                     new AccessLevel { Id = 2, Level = "Кладовщик" }
            );
            #endregion

            #region WarehouseStatusesDefaultData
            modelBuilder.Entity<WarehouseStatus>().HasData(
                     new WarehouseStatus { Id = 1, Status = "Открыт" },
                     new WarehouseStatus { Id = 2, Status = "Закрыт" }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
            #region EmployeePositionsDefaultData
            modelBuilder.Entity<EmployeePosition>().HasData(
                     new EmployeePosition { Id = 1, Position = "Администратор" },
                     new EmployeePosition { Id = 2, Position = "Директор" },
                     new EmployeePosition { Id = 3, Position = "Кладовщик" }
            );
            #endregion

            #region EmployeeStatusesDefaultData
            modelBuilder.Entity<EmployeeStatus>().HasData(
                     new EmployeeStatus { Id = 1, Status = "В сети" },
                     new EmployeeStatus { Id = 2, Status = "Не в сети" }
            );
            #endregion

            #region WorkGroupsDefaultData
            modelBuilder.Entity<WorkGroup>().HasData(
                     new WorkGroup { Id = 1, Group = "Руководство" }
            );
            #endregion
        }
    }
}
