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
using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Warehouse_accounting.Storage.ViewModels;

namespace Warehouse_accounting.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserControl _currentPage;
        public UserControl CurrentPage 
        {
            get { return _currentPage; }
            set { _currentPage = value; RaisePropertyChanged(() => CurrentPage); }
        }

        public MainWindowViewModel()
        {
            MainWindowViewModelStorage.Storage = this;
        }

        public ICommand bSidenavCustomWarehousesDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = new WarehousesDataGridElement());
            }
        }
    }
}
