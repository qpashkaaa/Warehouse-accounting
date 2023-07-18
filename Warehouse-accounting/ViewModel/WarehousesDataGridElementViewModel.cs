using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    public class WarehousesDataGridElementViewModel : ViewModelBase
    {
        private UserControl CustomWarehousesDataGrid;

        private UserControl _currentDataGrid;
        public UserControl CurrentDataGrid
        {
            get { return _currentDataGrid; }
            set { _currentDataGrid = value; RaisePropertyChanged(() => CurrentDataGrid); }
        }

        public WarehousesDataGridElementViewModel()
        {
            CustomWarehousesDataGrid = new CustomWarehousesDataGrid();
            CurrentDataGrid = CustomWarehousesDataGrid;
        }
    }
}
