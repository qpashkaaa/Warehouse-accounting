﻿using System;
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

        public void CloseModalWindow()
        {
            modalWindow.Close();
        }
    }
}
