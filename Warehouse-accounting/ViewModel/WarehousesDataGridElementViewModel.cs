using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.Model;
using Warehouse_accounting.Storage;
using Warehouse_accounting.Tools;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    public class WarehousesDataGridElementViewModel : ViewModelBase
    {
        #region VARIABLES
        private int countTableElements;
        public int CountTableElements
        {
            get { return countTableElements; }
            set
            {
                countTableElements = value;
                RaisePropertyChanged("CountTableElements");
            }
        }

        private int activePage;
        public int ActivePage
        {
            get { return activePage; }
            set
            {
                activePage = value;
                RaisePropertyChanged("ActivePage");
            }
        }
        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set
            {
                tableName = value;
                RaisePropertyChanged("TableName");
            }
        }

        private UserControl _currentDataGrid;
        public UserControl CurrentDataGrid
        {
            get { return _currentDataGrid; }
            set { _currentDataGrid = value; RaisePropertyChanged(() => CurrentDataGrid); }
        }

        private double _frameOpacity;
        public double FrameOpacity
        {
            get { return _frameOpacity; }
            set { _frameOpacity = value; RaisePropertyChanged(() => FrameOpacity); }
        }
        private IWindowService _windowService;
        private void OnOpenModalAddNewWarehouseWindow()
        {
            _windowService.OpenModalWindowAddNewWarehouse();
        }
        #endregion

        #region CONSTRUCTOR
        public WarehousesDataGridElementViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            WarehousesDataGridElementViewModelStorage.Storage = this;
            ShowWarehouseTable();
        }
        #endregion

        #region BUTTON_COMMANDS
        public ICommand bOpenAddModalWindow_Click
        {
            get
            {
                return new RelayCommand(() => OpenAddModalWindow());
            }
        }
        #endregion

        #region WAREHOUSES_TABLES_METHOODS
        public void ShowWarehouseTable()
        {
            TableName = "Склады";
            CountTableElements = WarehouseDataWorker.GetWarehouses().Count;
            new CustomWarehousesDataGridViewModel(1);
        }

        private void OpenAddModalWindow()
        {
            if (TableName == "Склады")
            {
                OnOpenModalAddNewWarehouseWindow();
            }
        }
        #endregion
    }
}
