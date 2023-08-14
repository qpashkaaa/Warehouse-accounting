using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.Model;
using Warehouse_accounting.Storage;
using Warehouse_accounting.View.Components;
using GalaSoft.MvvmLight.Command;

namespace Warehouse_accounting.ViewModel
{
    public class CustomWarehousesDataGridViewModel : ViewModelBase, IDataGridViewModel
    {
        #region VARIABLES
        private string SearchElement;
        private const int countTableRows = 7;
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
        #endregion

        #region CONSTRUCTOR
        public CustomWarehousesDataGridViewModel(int _activePage, string searchElement)
        {
            DataGridViewModelStorage.Storage = this;
            List<Warehouse> warehouses = new List<Warehouse>();
            SearchElement = searchElement;
            if (SearchElement != "")
            {
                warehouses = WarehouseDataWorker.GetWarehousesContains(SearchElement);
            }
            else
            {
                warehouses = WarehouseDataWorker.GetWarehouses();
            }
            CountTableElements = warehouses.Count;
            if (_activePage == 0)
            {
                ActivePage = (int)Math.Ceiling((double)CountTableElements / countTableRows);
            }
            else
            {
                ActivePage = _activePage;
            }
            DrawTable();
        }
        #endregion


        #region BUTTON_COMMANDS
        public ICommand bFooterForwardEmployeesPositionsDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => ChangeActivePage("Forward"));
            }
        }

        public ICommand bFooterBackEmployeesPositionsDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => ChangeActivePage("Back"));
            }
        }
        #endregion

        #region DRAW_METHOODS
        private void ChangeActivePage(string operation)
        {
            if (operation == "Forward")
            {
                double countPages = Math.Ceiling((double)countTableElements / countTableRows);
                if (ActivePage + 1 > countPages)
                    ActivePage = ActivePage;
                else
                    ActivePage += 1;
            }
            else if (operation == "Back")
            {
                if (ActivePage - 1 == 0)
                    ActivePage = ActivePage;
                else
                    ActivePage -= 1;
            }
            DrawTable();
        }

        private void DrawTable()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            if (SearchElement != "")
            {
                warehouses = WarehouseDataWorker.GetWarehousesRangeContains(ActivePage, SearchElement);
            }
            else
            {
                warehouses = WarehouseDataWorker.GetWarehousesRange(ActivePage);
            }
            UserControl dataGrid = new CustomWarehousesDataGrid(warehouses, CountTableElements, ActivePage);
            WarehousesDataGridElementViewModelStorage.Storage.CurrentDataGrid = dataGrid;
        }
        #endregion
    }
}
