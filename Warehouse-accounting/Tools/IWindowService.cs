using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Tools
{
    public interface IWindowService
    {
        void OpenMainWindow();

        void OpenAuthorizationWindow();

        void OpenModalWindowAddNewEmployee();

        void CloseModalWindow();
    }
}
