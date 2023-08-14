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
using Warehouse_accounting.Storage;
using Warehouse_accounting.Tools;

namespace Warehouse_accounting.ViewModel
{
    public class ModalWindowAddNewPositionViewModel : ViewModelBase
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
        public string Position { get; set; } = "";
        #endregion

        #region CONSTRUCTOR
        public ModalWindowAddNewPositionViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            CorrectData = true;
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
        public ICommand bAddNewPosition_Click
        {
            get
            {
                return new RelayCommand(() => AddNewPositionInDatabase());
            }
        }
        #endregion

        #region METHOODS
        private void AddNewPositionInDatabase()
        {
            if (Position == "")
            {
                CorrectData = false;
            }
            else
            {
                CorrectData = true;

                // get responce for show result modal window
                string response = EmployeeDataWorker.AddEmployeePosition(Position);

                // update data grid Element header (table name, and elements count)
                EmployeesDataGridElementViewModelStorage.Storage.ShowEmployeePositionsTable();

                // set data grid active last page 
                new CustomEmployeesPostitionsDataGridViewModel(0, "");

                // close modal window
                OnCloseModalWindow();

                OnOpenRequestResultModalWindow(response);
            }
        }
        #endregion
    }
}
