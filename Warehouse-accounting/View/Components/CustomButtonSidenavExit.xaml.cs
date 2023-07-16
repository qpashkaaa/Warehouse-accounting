﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomButtonSidenavExit.xaml
    /// </summary>
    public partial class CustomButtonSidenavExit : UserControl
    {
        public CustomButtonSidenavExit()
        {
            InitializeComponent();
        }

        private void btnExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Owner = System.Windows.Application.Current.MainWindow;
            authorizationWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            authorizationWindow.Show();
        }
    }
}
