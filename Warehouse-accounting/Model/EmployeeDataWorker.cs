using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_accounting.Data;
using Warehouse_accounting.Model.DbModels;
using System.Linq;
using System.Timers;
using Warehouse_accounting.Storage;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

        public static List<Employee> GetEmployeesRange(int activePage)
        {
            using (AppDbContext db = new AppDbContext())
            {
                int rangeStartValue = (activePage * 7) - 7;
                var result = db.Employees.
                    Skip(rangeStartValue).Take(7).
                    Include(d => d.EmployeePosition).
                    Include(d => d.WorkGroup).
                    Include(d=> d.EmployeeStatus).
                    ToList();
                return result;
            }
        }

        public static List<WorkGroup> GetEmployeeWorkGroups()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.WorkGroups.AsNoTracking().ToList();
                return result;
            }
        }

        public static List<string> GetEmployeeWorkGroupsText()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.WorkGroups.Select(d => d.Group).ToList();
                return result;
            }
        }

        public static List<EmployeeStatus> GetEmployeeStatuses()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.EmployeeStatuses.AsNoTracking().ToList();
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

        public static List<string> GetEmployeePositionsText()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.EmployeePositions.Select(d => d.Position).ToList();
                return result;
            }
        }

        public static List<EmployeePosition> GetEmployeePositionsRange(int activePage)
        {
            using (AppDbContext db = new AppDbContext())
            {
                int rangeStartValue = (activePage * 7) - 6;
                int rangeEndValue = (activePage * 7);
                var result = db.EmployeePositions.
                    Where(d => d.Id >= rangeStartValue && d.Id <= rangeEndValue).
                    ToList();
                return result;
            }
        }
        #endregion

        #region ADD_METHOODS
        // add employee
        public static string AddEmployee(string surname, string name, string patronymic, string uniqueNumber, string employeePosition, string workGroup)
        {
            using (AppDbContext db = new AppDbContext())
            {
                // Take objects from string
                int employeePositionId = db.EmployeePositions.Where(d => d.Position == employeePosition).FirstOrDefault().Id;
                int workGroupId = db.WorkGroups.Where(d => d.Group == workGroup).FirstOrDefault().Id;

                // create new object
                Employee newEmployee = new Employee()
                {
                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    UniqueNumber = uniqueNumber,
                    EmployeePositionId = employeePositionId,
                    EmployeeStatusId = 2,
                    WorkGroupId = workGroupId
                };

                // add object
                db.Employees.Add(newEmployee);
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

        #region CHECK_METHOODS
        public static bool CheckEmployeeUniqueNumber(string uniqueNumber)
        {
            using (AppDbContext db = new AppDbContext())
            {
                bool result = db.Employees.Any(d => d.UniqueNumber == uniqueNumber);
                return result;
            }
        }
        #endregion
    }
}
