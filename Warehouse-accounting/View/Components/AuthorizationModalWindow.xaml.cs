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
using Warehouse_accounting.Storage;
using Warehouse_accounting.Tools;
using Warehouse_accounting.ViewModel;

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationModalWindow.xaml
    /// </summary>
    public partial class AuthorizationModalWindow : UserControl
    {
        public AuthorizationModalWindow()
        {
            InitializeComponent();
            var windowService = WindowServiceStorage.Storage;
            DataContext = new AuthorizationModalWindowViewModel(windowService);
        }
    }
}
