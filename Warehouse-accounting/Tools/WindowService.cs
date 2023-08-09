using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warehouse_accounting.View;

namespace Warehouse_accounting.Tools
{
    public class WindowService : IWindowService
    {
        private Window modalWindow;
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

        public void OpenModalWindowAddNewEmployeePosition()
        {
            var window = new ModalWindowAddNewPosition();
            modalWindow = window;
            OpenModalWindowMethood(window);
        }

        public void OpenModalWindowAddNewWarehouse()
        {
            var window = new ModalWindowAddNewWarehouse();
            modalWindow = window;
            OpenModalWindowMethood(window);
        }

        public void CloseModalWindow()
        {
            modalWindow.Close();
        }

        public void OpenModalWindowRequestResult(string message)
        {
            var mainWindow = System.Windows.Application.Current.MainWindow;
            var window = new ModalWindowRequestResult(message);
            window.WindowStartupLocation = WindowStartupLocation.Manual;
            window.Top = mainWindow.Top + 224;

            double left = mainWindow.Left + mainWindow.ActualWidth - window.Width;
            window.Left = left - 52;
            window.Show();
        }
    }
}
