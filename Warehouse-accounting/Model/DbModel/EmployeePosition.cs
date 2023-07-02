using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Model.DbModels
{
    public class EmployeePosition
    {
        public int Id { get; set; }
        public List<Employee> Employees { get; set; }
        public string Position { get; set; }
    }
}
