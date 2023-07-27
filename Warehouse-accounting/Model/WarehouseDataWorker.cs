using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Warehouse_accounting.Data;
using Warehouse_accounting.Model.DbModels;

namespace Warehouse_accounting.Model
{
    public static class WarehouseDataWorker
    {
        #region GET_METHOODS
        public static List<Warehouse> GetWarehouses()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Warehouses.ToList();
                return result;
            }
        }

        public static List<Warehouse> GetWarehousesRange(int activePage)
        {
            using (AppDbContext db = new AppDbContext())
            {
                int rangeStartValue = (activePage * 7) - 6;
                int rangeEndValue = (activePage * 7);
                var result = db.Warehouses.
                    Where(d => d.Id >= rangeStartValue && d.Id <= rangeEndValue).
                    Include(d => d.WarehouseAddress).
                    Include(d => d.WarehouseStatus).
                    ToList();
                return result;
            }
        }

        public static List<WarehouseStatus> GetWarehouseStatuses()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.WarehouseStatuses.ToList();
                return result;
            }
        }
        public static List<WarehouseLoading> GetWarehouseLoadings()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.WarehouseLoadings.ToList();
                return result;
            }
        }
        #endregion

        #region ADD_METHOODS
        // add warehouse
        public static string AddWarehouse(string name, string uniqueNumber)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Warehouse newWarehouse = new Warehouse()
                {
                    Name = name,
                    UniqueNumber = uniqueNumber
                };
                db.Warehouses.Add(newWarehouse);
                db.SaveChanges();
            }
            return "Данные добавлены";
        }

        // add warehouse address
        public static string AddWarehouseAddress(string city, string street, string houseNumber)
        {
            using (AppDbContext db = new AppDbContext())
            {
                WarehouseAddress newWarehouseAddress = new WarehouseAddress()
                {
                    City = city,
                    Street = street,
                    HouseNumber = houseNumber
                };
                db.WarehouseAddresses.Add(newWarehouseAddress);
                db.SaveChanges();
            }
            return "Данные добавлены";
        }

        // add warehouse loading
        public static string AddWarehouseLoading(int loadingPercent, Warehouse warehouse)
        {
            using (AppDbContext db = new AppDbContext())
            {
                WarehouseLoading newWarehouseLoading = new WarehouseLoading()
                {
                    LoadingPercent = loadingPercent,
                    Warehouse = warehouse
                };
                db.WarehouseLoadings.Add(newWarehouseLoading);
                db.SaveChanges();
            }
            return "Данные добавлены";
        }

        // add work group
        public static string AddWorkGroup(string group)
        {
            using (AppDbContext db = new AppDbContext())
            {
                WorkGroup newWorkGroup = new WorkGroup()
                {
                    Group = group
                };
                db.WorkGroups.Add(newWorkGroup);
                db.SaveChanges();
            }
            return "Данные добавлены";
        }
        #endregion

        #region DELETE_METHOODS
        // delete warehouse
        public static string DeleteWarehouse(Warehouse warehouse)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Warehouses.Remove(warehouse);
                db.SaveChanges();
            }
            return "Данные удалены";
        }

        // delete warehouse address
        public static string DeleteWarehouseAddress(WarehouseAddress warehouseAddress)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.WarehouseAddresses.Remove(warehouseAddress);
                db.SaveChanges();
            }
            return "Данные удалены";
        }

        // delete warehouse loading
        public static string DeleteWarehouseLoading(WarehouseLoading warehouseLoading)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.WarehouseLoadings.Remove(warehouseLoading);
                db.SaveChanges();
            }
            return "Данные удалены";
        }

        // delete work group
        public static string DeleteWorkGroup(WorkGroup workGroup)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.WorkGroups.Remove(workGroup);
                db.SaveChanges();
            }
            return "Данные удалены";
        }
        #endregion

        #region EDIT_METHOODS
        public static string EditWarehouse(Warehouse oldWarehouse, string newName, string newUniqueNumber)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Warehouse warehouse = db.Warehouses.FirstOrDefault(w => w.Id == oldWarehouse.Id);
                warehouse.Name = newName;
                warehouse.UniqueNumber = newUniqueNumber;
                db.SaveChanges();
            }
            return "Данные обновлены";
        }

        public static string EditWarehouseAddress(WarehouseAddress oldWarehouseAddress, string newCity, string newStreet, string newHouseNumber)
        {
            using (AppDbContext db = new AppDbContext())
            {
                WarehouseAddress warehouseAddress = db.WarehouseAddresses.FirstOrDefault(a => a.Id == oldWarehouseAddress.Id);
                warehouseAddress.City = newCity;
                warehouseAddress.Street = newStreet;
                warehouseAddress.HouseNumber = newHouseNumber;
                db.SaveChanges();
            }
            return "Данные обновлены";
        }

        public static string EditWarehouseLoading(WarehouseLoading oldWarehouseLoading, int newLoadingPercent, Warehouse newWarehouse)
        {
            using (AppDbContext db = new AppDbContext())
            {
                WarehouseLoading warehouseLoading = db.WarehouseLoadings.FirstOrDefault(l => l.Id == oldWarehouseLoading.Id);
                warehouseLoading.LoadingPercent = newLoadingPercent;
                warehouseLoading.Warehouse = newWarehouse;
                db.SaveChanges();
            }
            return "Данные обновлены";
        }

        public static string EditWorkGroup(WorkGroup oldWorkGroup, string newGroup)
        {
            using (AppDbContext db = new AppDbContext())
            {
                WorkGroup workGroup = db.WorkGroups.FirstOrDefault(g => g.Id == oldWorkGroup.Id);
                workGroup.Group = newGroup;
                db.SaveChanges();
            }
            return "Данные обновлены";
        }
        #endregion
    }
}
