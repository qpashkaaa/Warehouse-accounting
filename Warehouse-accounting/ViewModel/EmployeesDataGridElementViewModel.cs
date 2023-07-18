using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    internal class EmployeesDataGridElementViewModel : ViewModelBase
    {
        private UserControl CustomEmployeesDataGrid;

        private UserControl _currentDataGrid;
        public UserControl CurrentDataGrid
        {
            get { return _currentDataGrid; }
            set { _currentDataGrid = value; RaisePropertyChanged(() => CurrentDataGrid); }
        }

        public EmployeesDataGridElementViewModel()
        {
            CustomEmployeesDataGrid = new CustomEmployeesDataGrid();
            CurrentDataGrid = CustomEmployeesDataGrid;
        }
    }
}
