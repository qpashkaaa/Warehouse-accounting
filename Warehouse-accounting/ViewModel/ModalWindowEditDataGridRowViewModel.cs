﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Warehouse_accounting.Model;
using Warehouse_accounting.Storage;
using Warehouse_accounting.Tools;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    public class ModalWindowEditDataGridRowViewModel : ViewModelBase
    {
        #region VARIABELS
        private int IdElem;
        private int OpenTable;
        private IWindowService _windowService;
        private void OnOpenRequestResultModalWindow(string message)
        {
            _windowService.OpenModalWindowRequestResult(message);
        }
        #endregion

        #region CONSTRUCTOR
        public ModalWindowEditDataGridRowViewModel(int idElem, int openTable, IWindowService windowService)
        {
            _windowService = windowService;
            IdElem = idElem;
            OpenTable = openTable;
        }
        #endregion

        #region BUTTON_COMMANDS
        public ICommand bUpdateModalWindow_Click
        {
            get
            {
                return new RelayCommand(() => Update());
            }
        }
        public ICommand bDeleteModalWindow_Click
        {
            get
            {
                return new RelayCommand(() => Delete());
            }
        }
        #endregion


        #region METHOODS
        private void Delete()
        {
            if (OpenTable == TablesIdStorage.EMPLOYEES_TABLE)
            {
                string response = EmployeeDataWorker.DeleteEmployee(IdElem);
                EmployeesDataGridElementViewModelStorage.Storage.ShowEmployeeTable();
                new CustomEmployeesDataGridViewModel(1);
                OnOpenRequestResultModalWindow(response);
            }
            if (OpenTable == TablesIdStorage.EMPLOYEES_POSITIONS_TABLE)
            {
                string response = EmployeeDataWorker.DeletePosition(IdElem);
                EmployeesDataGridElementViewModelStorage.Storage.ShowEmployeePositionsTable();
                new CustomEmployeesPostitionsDataGridViewModel(1);
                OnOpenRequestResultModalWindow(response);
            }
            if (OpenTable == TablesIdStorage.WAREHOUSES_TABLE)
            {
                string response = WarehouseDataWorker.DeleteWarehouse(IdElem);
                WarehousesDataGridElementViewModelStorage.Storage.ShowWarehouseTable();
                new CustomWarehousesDataGridViewModel(1);
                OnOpenRequestResultModalWindow(response);
            }
        }
        private void Update()
        {
            if (OpenTable == TablesIdStorage.EMPLOYEES_TABLE)
            {
                Trace.WriteLine($"Обновляем {IdElem} в таблице сотрудники");
            }
            if (OpenTable == TablesIdStorage.EMPLOYEES_POSITIONS_TABLE)
            {
                Trace.WriteLine($"Обновляем {IdElem} в таблице должности");
            }
            if (OpenTable == TablesIdStorage.WAREHOUSES_TABLE)
            {
                Trace.WriteLine($"Обновляем {IdElem} в таблице склады");
            }
        }
        #endregion
    }
}
