using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warehouse_accounting.View;

namespace Warehouse_accounting.Tools
{
    public class WindowService : IWindowService
    {
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
    }
}
