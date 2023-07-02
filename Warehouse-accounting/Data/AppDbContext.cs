using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using Warehouse_accounting.Model.DbModels;

namespace Warehouse_accounting.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() => Database.EnsureCreated();

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

        #region AUTH_TABLES
        public DbSet<AuthorizationData> AuthorizationDatas { get; set; }
        #endregion

        #region WAREHOUSES_TABLES
        public DbSet<Warehouse> Warehouses { get; set; }
        #endregion

        #region EMPLOYEE_TABLES
        public DbSet<Employee> Employees { get; set; }
        #endregion
    }
}
