using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.View;
using static System.Net.Mime.MediaTypeNames;

namespace Warehouse_accounting.Tools
{
    public class WindowService : IWindowService
    {
        private Window modalWindow;
        private Window mainWindow;
        private Window modalWindowRequestResult;
        private void OpenModalWindowMethood(Window window)
        {
            var mainWindow = System.Windows.Application.Current.MainWindow;
            window.Owner = mainWindow;
            window.Top = mainWindow.Top + 32;
            window.Left = mainWindow.Left;
            window.ShowDialog();
        }

        public void OpenMainWindow()
        {
            var window = new MainWindow();
            mainWindow = window;
            window.Show();
        }

        public void OpenAuthorizationWindow()
        {
            var window = new AuthorizationWindow();
            window.Show();
        }

        public void OpenModalWindowAddNewEmployee()
        {
            var window = new ModalWindowAddNewEmployee();
            modalWindow = window;
            OpenModalWindowMethood(window);
        }

        public void OpenModalWindowEditEmployee(Employee employee)
        {
            var window = new ModalWindowEditEmployee(employee);
            modalWindow = window;
            OpenModalWindowMethood(window);
        }

        public void OpenModalWindowAddNewEmployeePosition()
        {
            var window = new ModalWindowAddNewPosition();
            modalWindow = window;
            OpenModalWindowMethood(window);
        }

        public void OpenModalWindowEditEmployeePosition(EmployeePosition employeePosition)
        {
            var window = new ModalWindowEditEmployeePosition(employeePosition);
            modalWindow = window;
            OpenModalWindowMethood(window);
        }

        public void OpenModalWindowAddNewWarehouse()
        {
            var window = new ModalWindowAddNewWarehouse();
            modalWindow = window;
            OpenModalWindowMethood(window);
        }

        public void OpenModalWindowEditWarehouse(Warehouse warehouse)
        {
            var window = new ModalWindowEditWarehouse(warehouse);
            modalWindow = window;
            OpenModalWindowMethood(window);
        }

        public void CloseModalWindow()
        {
            mainWindow.Topmost = true;
            modalWindow.Close();
            Thread.Sleep(30);
            mainWindow.Topmost = false;
        }

        public void OpenModalWindowRequestResult(string message)
        {
            if (modalWindowRequestResult != null)
            {
                modalWindowRequestResult.Close();
            }
            modalWindowRequestResult = new ModalWindowRequestResult(message, mainWindow);
            modalWindowRequestResult.WindowStartupLocation = WindowStartupLocation.Manual;
            modalWindowRequestResult.Top = mainWindow.Top + 224;

            double left = mainWindow.Left + mainWindow.ActualWidth - modalWindowRequestResult.Width;
            modalWindowRequestResult.Left = left - 52;
            modalWindowRequestResult.Topmost = true;
            modalWindowRequestResult.Show();
        }
    }
}
