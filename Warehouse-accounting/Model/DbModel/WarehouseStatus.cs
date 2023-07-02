using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Model.DbModels
{
    public class WarehouseStatus
    {
        public int Id { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public string Status { get; set; }
    }
}
