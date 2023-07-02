using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Model.DbModels
{
    public class WarehouseLoading
    {
        public int Id { get; set; }
        public int LoadingPercent { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
