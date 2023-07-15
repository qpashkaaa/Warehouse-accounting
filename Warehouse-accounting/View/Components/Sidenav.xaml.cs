using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для Sidenav.xaml
    /// </summary>
    public partial class Sidenav : UserControl
    {
        public Sidenav()
        {
            InitializeComponent();
        }

        private void BackToAuthorizationWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Owner = System.Windows.Application.Current.MainWindow;
            authorizationWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            authorizationWindow.Show();
        }
    }
}
