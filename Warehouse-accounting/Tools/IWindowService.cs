using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_accounting.Model.DbModels;

namespace Warehouse_accounting.Tools
{
    public interface IWindowService
    {
        void OpenMainWindow();

        void OpenAuthorizationWindow();

        void OpenModalWindowAddNewEmployee();
        void OpenModalWindowEditEmployee(Employee employee);
        void OpenModalWindowAddNewEmployeePosition();
        void OpenModalWindowEditEmployeePosition(EmployeePosition employeePosition);
        void OpenModalWindowAddNewWarehouse();
        void OpenModalWindowEditWarehouse(Warehouse warehouse);

        void CloseModalWindow();

        void OpenModalWindowRequestResult(string message);
    }
}
