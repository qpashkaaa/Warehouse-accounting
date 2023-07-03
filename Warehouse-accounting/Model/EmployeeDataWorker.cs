using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_accounting.Data;
using Warehouse_accounting.Model.DbModels;
using System.Linq;
using System.Timers;

namespace Warehouse_accounting.Model
{
    public static class EmployeeDataWorker
    {
        #region GET_METHOODS
        public static List<Employee> GetEmployees()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Employees.ToList();
                return result;
            }
        }

        public static List<EmployeePosition> GetEmployeePositions()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.EmployeePositions.ToList();
                return result;
            }
        }
        #endregion

        #region ADD_METHOODS
        // add employee
        public static string AddEmployee(string surname, string name, string patronymic, string uniqueNumber, EmployeePosition employeePosition, WorkGroup workGroup, EmployeeStatus employeeStatus)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Employee newEmployee = new Employee()
                {
                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    UniqueNumber = uniqueNumber,
                    EmployeePosition = employeePosition,
                    EmployeeStatus = employeeStatus,
                    WorkGroup = workGroup
                };
                db.Employees.Add(newEmployee);
                db.SaveChanges();
            }
            return "Данные добавлены";
        }

        // add position
        public static string AddEmployeePosition(string position)
        {
            using (AppDbContext db = new AppDbContext())
            {
                EmployeePosition newEmployeePosition = new EmployeePosition()
                {
                    Position = position
                };
                db.EmployeePositions.Add(newEmployeePosition);
                db.SaveChanges();
            }
            return "Данные добавлены";
        }
        #endregion

        #region DELETE_METHOODS
        // delete employee
        public static string DeleteEmployee(Employee employee)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            return "Данные удалены";
        }

        // delete position
        public static string DeletePosition(EmployeePosition employeePosition)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.EmployeePositions.Remove(employeePosition);
                db.SaveChanges();
            }
            return "Данные удалены";
        }
        #endregion

        #region EDIT_METHOODS
        public static string EditEmployee(Employee oldEmployee, string newSurname, string newName, string newPatronymic, string newUniqueNumber, EmployeePosition newEmployeePosition, WorkGroup newWorkGroup, EmployeeStatus newEmployeeStatus)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Employee employee = db.Employees.FirstOrDefault(e => e.Id == oldEmployee.Id);
                employee.Surname = newSurname;
                employee.Name = newName;
                employee.Patronymic = newPatronymic;
                employee.UniqueNumber = newUniqueNumber;
                employee.EmployeePosition = newEmployeePosition;
                employee.WorkGroup = newWorkGroup;
                employee.EmployeeStatus = newEmployeeStatus;
                db.SaveChanges();
            }
            return "Данные обновлены";
        }

        public static string EditPosition(EmployeePosition oldEmployeePosition, string newPosition)
        {
            using (AppDbContext db = new AppDbContext())
            {
                EmployeePosition employeePosition = db.EmployeePositions.FirstOrDefault(p => p.Id == oldEmployeePosition.Id);
                employeePosition.Position = newPosition;
                db.SaveChanges();
            }
            return "Данные обновлены";
        }
        #endregion
    }
}
