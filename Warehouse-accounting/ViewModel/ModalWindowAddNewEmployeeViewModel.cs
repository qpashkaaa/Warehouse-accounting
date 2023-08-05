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
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    public class ModalWindowAddNewEmployeeViewModel : ViewModelBase
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
        public ModalWindowAddNewEmployeeViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            CorrectData = true;
            PositionsText = EmployeeDataWorker.GetEmployeePositionsText();
            WorkGroupsText = EmployeeDataWorker.GetEmployeeWorkGroupsText();
            UniqueNumber = CreateUniqueId();
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
        public ICommand bAddNewEmployee_Click
        {
            get
            {
                return new RelayCommand(() => AddNewEmployeeInDatabase());
            }
        }
        #endregion

        #region METHOODS
        private string CreateUniqueId()
        {
            // creating variables
            Guid guidValue;
            MD5 md5;
            Guid hashed;
            string uniqueID;

            // first unique number generation
            guidValue = Guid.NewGuid();
            md5 = MD5.Create();
            hashed = new Guid(md5.ComputeHash(guidValue.ToByteArray()));
            uniqueID = "#" + hashed.ToString().Replace("-", "").Substring(0, 15).ToUpper();

            //check repeat's numbers
            while (EmployeeDataWorker.CheckEmployeeUniqueNumber(uniqueID) == true)
            {
                guidValue = Guid.NewGuid();
                md5 = MD5.Create();
                hashed = new Guid(md5.ComputeHash(guidValue.ToByteArray()));
                uniqueID = "#" + hashed.ToString().Replace("-", "").Substring(0, 15).ToUpper();
            }

            // if repeat's number not founded, return unique number
            return uniqueID;
        }

        private void AddNewEmployeeInDatabase()
        {
            if (Name == "" || Surname == "" || Patronymic == "" || UniqueNumber == "" || SelectedPosition == "" || SelectedWorkGroup == "")
            {
                CorrectData = false;
            }
            else
            {
                CorrectData = true;

                // get responce for show result modal window
                string response = EmployeeDataWorker.AddEmployee(Surname, Name, Patronymic, UniqueNumber, SelectedPosition, SelectedWorkGroup);

                // update data grid Element header (table name, and elements count)
                EmployeesDataGridElementViewModelStorage.Storage.ShowEmployeeTable();

                // set data grid active last page 
                new CustomEmployeesDataGridViewModel(0);

                // close modal window
                OnCloseModalWindow();

                OnOpenRequestResultModalWindow(response);
            }
        }
        #endregion
    }
}
