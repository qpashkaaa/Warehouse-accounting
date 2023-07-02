using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Model.DbModels
{
    public class WorkGroup
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public Warehouse Warehouse { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
