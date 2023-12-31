﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.Model;
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.Storage;
using Warehouse_accounting.Tools;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    public class EmployeesDataGridElementViewModel : ViewModelBase
    {
        #region VARIABLES
        private string searchElement;
        public string SearchElement
        {
            get { return searchElement; }
            set
            {
                searchElement = value;
                RaisePropertyChanged("SearchElement");
            }
        }
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
        private void OnOpenModalAddNewEmployeeWindow()
        {
            _windowService.OpenModalWindowAddNewEmployee();
        }

        private void OnOpenModalAddNewEmployeePositionWindow()
        {
            _windowService.OpenModalWindowAddNewEmployeePosition();
        }
        #endregion

        #region CONSTRUCTOR
        public EmployeesDataGridElementViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            EmployeesDataGridElementViewModelStorage.Storage = this;
            SearchElement = "";
            ShowEmployeeTable();
        }
        #endregion

        #region BUTTON_COMMANDS
        public ICommand bTabControlEmployeesDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => ShowEmployeeTable());
            }
        }

        public ICommand bTabControlEmployeesPositionsDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => ShowEmployeePositionsTable());
            }
        }

        public ICommand bOpenAddModalWindow_Click
        {
            get
            {
                return new RelayCommand(() => OpenAddModalWindow());
            }
        }

        public ICommand tbSearch_KeyUp
        {
            get
            {
                return new RelayCommand(() => SearchElements());
            }
        }
        #endregion

        #region EMPLOYEES_TABLES_METHOODS
        public void ShowEmployeeTable()
        {
            TableName = "Сотрудники";
            SearchElement = "";
            CountTableElements = EmployeeDataWorker.GetEmployees().Count;
            new CustomEmployeesDataGridViewModel(1, SearchElement);
        }

        public void ShowEmployeePositionsTable()
        {
            TableName = "Должности";
            SearchElement = "";
            CountTableElements = EmployeeDataWorker.GetEmployeePositions().Count;
            new CustomEmployeesPostitionsDataGridViewModel(1, SearchElement);
        }

        private void SearchElements()
        {
            if (SearchElement.Length % 3 == 0)
            {
                if (TableName == "Сотрудники")
                {
                    CountTableElements = EmployeeDataWorker.GetEmployeesContains(SearchElement).Count;
                    new CustomEmployeesDataGridViewModel(1, SearchElement);
                }
                if (TableName == "Должности")
                {
                    CountTableElements = EmployeeDataWorker.GetEmployeePositionsContains(SearchElement).Count;
                    new CustomEmployeesPostitionsDataGridViewModel(1, SearchElement);
                }
            }
        }

        private void OpenAddModalWindow()
        {
            if (TableName == "Сотрудники")
            {
                OnOpenModalAddNewEmployeeWindow();
            }
            if (TableName == "Должности")
            {
                OnOpenModalAddNewEmployeePositionWindow();
            }
        }
        #endregion
    }
}
