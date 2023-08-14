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
        #region GET_EMPLOYEES_METHOODS
        public static List<Employee> GetEmployees()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Employees.ToList();
                return result;
            }
        }

        public static List<Employee> GetEmployeesContains(string searchElement)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Employees.Where(d => d.Surname.ToUpper().Contains(searchElement.ToUpper())).ToList();
                return result;
            }
        }

        public static Employee GetEmployeeById(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Employee result = db.Employees.FirstOrDefault(d => d.Id == id);
                return result;
            }
        }

        public static List<Employee> GetEmployeesRange(int activePage)
        {
            using (AppDbContext db = new AppDbContext())
            {
                int rangeStartValue = (activePage * 7) - 7;
                var result = db.Employees.
                    OrderBy(d => d.EmployeeStatusId).
                    Skip(rangeStartValue).Take(7).
                    Include(d => d.EmployeePosition).
                    Include(d => d.WorkGroup).
                    Include(d => d.EmployeeStatus).
                    ToList();
                return result;
            }
        }

        public static List<Employee> GetEmployeesRangeContains(int activePage, string searchElement)
        {
            using (AppDbContext db = new AppDbContext())
            {
                int rangeStartValue = (activePage * 7) - 7;
                var result = db.Employees.
                    Where(d => d.Surname.ToUpper().Contains(searchElement.ToUpper())).
                    OrderBy(d => d.EmployeeStatusId).
                    Skip(rangeStartValue).Take(7).
                    Include(d => d.EmployeePosition).
                    Include(d => d.WorkGroup).
                    Include(d => d.EmployeeStatus).
                    ToList();
                return result;
            }
        }
        #endregion

        #region GET_WORKG_GROUPS_METHOODS
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

        public static string GetEmployeeWorkGroupTextById(int workGroupId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.WorkGroups.FirstOrDefault(d => d.Id == workGroupId).Group.ToString();
                return result;
            }
        }

        public static WorkGroup GetEmployeeWorkGroupByText(string workGroupText)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.WorkGroups.FirstOrDefault(d => d.Group == workGroupText);
                return result;
            }
        }
        #endregion

        #region GET_STATUSES_METHOODS
        public static List<EmployeeStatus> GetEmployeeStatuses()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.EmployeeStatuses.AsNoTracking().ToList();
                return result;
            }
        }
        #endregion

        #region GET_POSITIONS_METHOODS
        public static List<EmployeePosition> GetEmployeePositions()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.EmployeePositions.ToList();
                return result;
            }
        }

        public static List<EmployeePosition> GetEmployeePositionsContains(string searchElement)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.EmployeePositions.Where(d => d.Position.ToUpper().Contains(searchElement.ToUpper())).ToList();
                return result;
            }
        }

        public static EmployeePosition GetEmployeePositionById(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                EmployeePosition result = db.EmployeePositions.FirstOrDefault(d => d.Id == id);
                return result;
            }
        }

        public static string GetEmployeePositionTextById(int positionId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.EmployeePositions.FirstOrDefault(d => d.Id == positionId).Position.ToString();
                return result;
            }
        }

        public static EmployeePosition GetEmployeePositionByText(string positionText)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.EmployeePositions.FirstOrDefault(d => d.Position == positionText);
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
                int rangeStartValue = (activePage * 7) - 7;
                var result = db.EmployeePositions.
                    Skip(rangeStartValue).Take(7).
                    ToList();
                return result;
            }
        }
        public static List<EmployeePosition> GetEmployeePositionsRangeContains(int activePage, string searchElement)
        {
            using (AppDbContext db = new AppDbContext())
            {
                int rangeStartValue = (activePage * 7) - 7;
                var result = db.EmployeePositions.
                    Where(d => d.Position.ToUpper().Contains(searchElement.ToUpper())).
                    Skip(rangeStartValue).Take(7).
                    ToList();
                return result;
            }
        }
        #endregion
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

                // add object
                db.EmployeePositions.Add(newEmployeePosition);
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
        #endregion

        #region DELETE_METHOODS
        // delete employee
        public static string DeleteEmployee(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Employee employee = db.Employees.FirstOrDefault(d => d.Id == id);
                db.Employees.Remove(employee);
                try
                {
                    int requestResult = db.SaveChanges();
                    if (requestResult == 1)
                    {
                        return "Данные удалены";
                    }
                    else
                    {
                        return "Ошибка удаления";
                    }
                }
                catch
                {
                    return "Ошибка удаления";
                }
            }
        }

        // delete position
        public static string DeletePosition(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                EmployeePosition employeePosition = db.EmployeePositions.FirstOrDefault(d => d.Id == id);
                db.EmployeePositions.Remove(employeePosition);
                try
                {
                    int requestResult = db.SaveChanges();
                    if (requestResult == 1)
                    {
                        return "Данные удалены";
                    }
                    else
                    {
                        return "Ошибка удаления";
                    }
                }
                catch
                {
                    return "Ошибка удаления";
                }
            }
        }
        #endregion

        #region EDIT_METHOODS
        public static string EditEmployee(Employee newEmployee)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Employee employee = db.Employees.FirstOrDefault(d => d.Id == newEmployee.Id);

                employee.Surname = newEmployee.Surname;
                employee.Name = newEmployee.Name;
                employee.Patronymic = newEmployee.Patronymic;
                employee.UniqueNumber = newEmployee.UniqueNumber;
                employee.EmployeePosition = newEmployee.EmployeePosition;
                employee.WorkGroup = newEmployee.WorkGroup;
                db.SaveChanges();
            }
            return "Данные изменены";
        }

        public static string EditEmployeePosition(EmployeePosition newEmployeePosition)
        {
            using (AppDbContext db = new AppDbContext())
            {
                EmployeePosition employeePosition = db.EmployeePositions.FirstOrDefault(d => d.Id == newEmployeePosition.Id);

                employeePosition.Position = newEmployeePosition.Position;
                db.SaveChanges();
            }
            return "Данные изменены";
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
