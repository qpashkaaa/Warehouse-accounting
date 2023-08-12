using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warehouse_accounting.Model;
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.Storage;
using Warehouse_accounting.Tools;

namespace Warehouse_accounting.ViewModel
{
    public class ModalWindowEditWarehouseViewModel : ViewModelBase
    {
        #region VARIABLES
        private IWindowService _windowService;
        private void OnCloseModalWindow()
        {
            _windowService.CloseModalWindow();
        }

        private void OnOpenRequestResultModalWindow(string message)
        {
            _windowService.OpenModalWindowRequestResult(message);
        }

        private bool correctData;
        public bool CorrectData
        {
            get { return correctData; }
            set
            {
                correctData = value;
                RaisePropertyChanged("CorrectData");
            }
        }

        private int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string UniqueNumber { get; set; } = "";
        public List<string> AddressesText { get; set; }

        public string SelectedAddress { get; set; } = "";
        #endregion

        #region CONSTRUCTOR
        public ModalWindowEditWarehouseViewModel(IWindowService windowService, Warehouse warehouse)
        {
            _windowService = windowService;
            CorrectData = true;

            Id = warehouse.Id;
            Name = warehouse.Name;
            UniqueNumber = warehouse.UniqueNumber;
            SelectedAddress = WarehouseDataWorker.GetWarehouseAddressTextById(warehouse.WarehouseAddressId);

            AddressesText = WarehouseDataWorker.GetWarehouseAddressesText();
        }
        #endregion

        #region BUTTON_COMMANDS
        public ICommand bCloseModalWindow_Click
        {
            get
            {
                return new RelayCommand(() => OnCloseModalWindow());
            }
        }
        public ICommand bEditWarehouse_Click
        {
            get
            {
                return new RelayCommand(() => EditWarehouseInDatabase());
            }
        }
        #endregion

        #region METHOODS
        private void EditWarehouseInDatabase()
        {
            if (Name == "" || UniqueNumber == "" || SelectedAddress == "")
            {
                CorrectData = false;
            }
            else
            {
                CorrectData = true;

                // get responce for show result modal window
                Warehouse newWarehouse = new Warehouse()
                {
                    Id = Id,
                    Name = Name,
                    UniqueNumber = UniqueNumber,
                    WarehouseAddress = WarehouseDataWorker.GetWarehouseAddressByText(SelectedAddress),
                };

                string response = WarehouseDataWorker.EditWarehouse(newWarehouse);

                // set data grid active on the last page
                new CustomWarehousesDataGridViewModel(0);

                // close modal window
                OnCloseModalWindow();

                OnOpenRequestResultModalWindow(response);
            }
        }
        #endregion
    }
}
