using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Warehouse_accounting.Model;
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.Storage;
using Warehouse_accounting.Tools;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    public class ModalWindowEditEmployeePositionViewModel : ViewModelBase
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
        public string Position { get; set; } = "";
        #endregion

        #region CONSTRUCTOR
        public ModalWindowEditEmployeePositionViewModel(IWindowService windowService, EmployeePosition employeePosition)
        {
            _windowService = windowService;
            CorrectData = true;

            Id = employeePosition.Id;
            Position = employeePosition.Position;
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
        public ICommand bEditPosition_Click
        {
            get
            {
                return new RelayCommand(() => EditPositionInDatabase());
            }
        }
        #endregion

        #region METHOODS
        private void EditPositionInDatabase()
        {
            if (Position == "")
            {
                CorrectData = false;
            }
            else
            {
                CorrectData = true;

                // get responce for show result modal window
                EmployeePosition newEmployeePosition = new EmployeePosition()
                {
                    Id = Id,
                    Position = Position
                };

                string response = EmployeeDataWorker.EditEmployeePosition(newEmployeePosition);

                // set data grid active on the last page
                new CustomEmployeesPostitionsDataGridViewModel(0, "");

                // close modal window
                OnCloseModalWindow();

                OnOpenRequestResultModalWindow(response);
            }
        }
        #endregion
    }
}
