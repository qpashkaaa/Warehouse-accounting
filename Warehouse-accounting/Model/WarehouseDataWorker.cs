using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
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
                int rangeStartValue = (activePage * 7) - 7;
                var result = db.Warehouses.
                    OrderBy(d => d.WarehouseStatus).
                    Skip(rangeStartValue).Take(7).
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

        public static List<string> GetWarehouseAddressesText()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.WarehouseAddresses.Select(d => $"{d.City}, {d.Street}, {d.HouseNumber}").ToList();
                return result;
            }
        }
        #endregion

        #region ADD_METHOODS
        // add warehouse
        public static string AddWarehouse(string name, string uniqueNumber, string address)
        {
            using (AppDbContext db = new AppDbContext())
            {
                // Take objects from string
                Trace.WriteLine(address);
                List<string> splitAddress = address.Split(", ").ToList();
                WarehouseAddress selectedAddress = new WarehouseAddress 
                {
                    City = splitAddress[0],
                    Street = splitAddress[1],
                    HouseNumber = splitAddress[2]
                };

                int warehouseAddressId = db.WarehouseAddresses.
                    Where(d => d.City == selectedAddress.City && d.Street == selectedAddress.Street && d.HouseNumber == selectedAddress.HouseNumber).
                    FirstOrDefault().Id;

                // create new object
                 Warehouse newWarehouse = new Warehouse()
                 {
                     Name = name,
                     UniqueNumber = uniqueNumber,
                     WarehouseAddressId = warehouseAddressId,
                     WarehouseStatusId = 2,
                 };

                 // add object
                 db.Warehouses.Add(newWarehouse);
                 try
                 {
                     int requestResult = db.SaveChanges();
                     if (requestResult == 1)
                     {
                         return "Данные добавлены";
                     }
                     else
                     {
                         return "Ошибка добавления";
                     }
                 }
                 catch
                 {
                     return "Ошибка добавления";
                 }
            }
        }
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
