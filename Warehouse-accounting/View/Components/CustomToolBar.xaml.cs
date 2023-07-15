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
    /// Логика взаимодействия для CustomToolBar.xaml
    /// </summary>
    public partial class CustomToolBar : UserControl
    {
        public CustomToolBar()
        {
            InitializeComponent();
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void CollapseApplication(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }
    }
}
