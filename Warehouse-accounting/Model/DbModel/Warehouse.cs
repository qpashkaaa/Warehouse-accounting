using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Model.DbModels
{
    public class Warehouse
    {
        public int Id { get; set; }
        public List<WarehouseLoading> WarehouseLoadings { get; set; }
        public string Name { get; set; }
        public string UniqueNumber { get; set; }
        public WarehouseAddress WarehouseAddress { get; set; }
        public WarehouseStatus WarehouseStatus { get; set; }
    }
}
