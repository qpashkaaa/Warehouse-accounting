using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class ModalWindowEditEmployeeViewModel : ViewModelBase
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
        public string Surname { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string UniqueNumber { get; set; } = "";
        public List<string> PositionsText { get; set; }
        public List<string> WorkGroupsText { get; set; }

        public string SelectedPosition { get; set; } = "";
        public string SelectedWorkGroup { get; set; } = "";
        #endregion

        #region CONSTRUCTOR
        public ModalWindowEditEmployeeViewModel(IWindowService windowService, Employee employee)
        {
            _windowService = windowService;
            CorrectData = true;

            // set data to textbox's and combobox's
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Patronymic = employee.Patronymic;
            UniqueNumber = employee.UniqueNumber;
            SelectedPosition = EmployeeDataWorker.GetEmployeePositionTextById(employee.EmployeePositionId);
            SelectedWorkGroup = EmployeeDataWorker.GetEmployeeWorkGroupTextById(employee.WorkGroupId);

            // comboBox Items
            PositionsText = EmployeeDataWorker.GetEmployeePositionsText();
            WorkGroupsText = EmployeeDataWorker.GetEmployeeWorkGroupsText();
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
        public ICommand bEditEmployee_Click
        {
            get
            {
                return new RelayCommand(() => EditEmployeeInDatabase());
            }
        }
        #endregion

        #region METHOODS

        private void EditEmployeeInDatabase()
        {
            if (Name == "" || Surname == "" || Patronymic == "" || UniqueNumber == "" || SelectedPosition == "" || SelectedWorkGroup == "")
            {
                CorrectData = false;
            }
            else
            {
                CorrectData = true;

                // get responce for show result modal window
                Employee newEmployee = new Employee()
                {
                    Id = Id,
                    Name = Name,
                    Surname = Surname,
                    Patronymic = Patronymic,
                    UniqueNumber = UniqueNumber,
                    EmployeePosition = EmployeeDataWorker.GetEmployeePositionByText(SelectedPosition),
                    WorkGroup = EmployeeDataWorker.GetEmployeeWorkGroupByText(SelectedWorkGroup),
                };

                string response = EmployeeDataWorker.EditEmployee(newEmployee);

                // set data grid active on the last page
                new CustomEmployeesDataGridViewModel(0, "");

                // close modal window
                OnCloseModalWindow();

                OnOpenRequestResultModalWindow(response);
            }
        }
        #endregion
    }
}
