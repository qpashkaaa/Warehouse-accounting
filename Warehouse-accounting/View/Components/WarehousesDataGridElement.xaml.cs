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
using Warehouse_accounting.ViewModel;

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для WarehousesDataGridElement.xaml
    /// </summary>
    public partial class WarehousesDataGridElement : UserControl
    {
        public WarehousesDataGridElement()
        {
            InitializeComponent();
            var windowService = WindowServiceStorage.Storage;
            DataContext = new WarehousesDataGridElementViewModel(windowService);
        }
    }
}
