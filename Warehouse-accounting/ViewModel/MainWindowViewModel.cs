using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.View;
using Warehouse_accounting.View.Components;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;

namespace Warehouse_accounting.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private UserControl WarehousesDataGridElement;
        private UserControl _currentPage;
        public UserControl CurrentPage 
        {
            get { return _currentPage; }
            set { _currentPage = value; RaisePropertyChanged(() => CurrentPage); }
        }

        public ICommand bSidenavCustomWarehousesDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = WarehousesDataGridElement);
            }
        }
    }
}
