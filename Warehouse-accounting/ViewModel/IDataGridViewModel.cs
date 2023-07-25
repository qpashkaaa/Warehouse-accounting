using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Warehouse_accounting.ViewModel
{
    interface IDataGridViewModel
    {
        private const int countTableRows = 7;
        public int CountTableElements { get; set; }
        public int ActivePage { get; set; }

        public ICommand bFooterForwardEmployeesPositionsDataGrid_Click { get; }
        public ICommand bFooterBackEmployeesPositionsDataGrid_Click { get; }
        private void ChangeActivePage(string operation) { }
        private void DrawTable() { }
    }
}
