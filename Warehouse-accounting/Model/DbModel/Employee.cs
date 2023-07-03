using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Model.DbModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string UniqueNumber { get; set; }
        public EmployeePosition EmployeePosition { get; set; }
        public WorkGroup WorkGroup { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }

    }
}
