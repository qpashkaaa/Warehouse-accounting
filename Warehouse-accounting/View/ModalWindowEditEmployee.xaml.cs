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
using System.Windows.Shapes;
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.Storage;
using Warehouse_accounting.ViewModel;

namespace Warehouse_accounting.View
{
    /// <summary>
    /// Логика взаимодействия для ModalWindowEditEmployee.xaml
    /// </summary>
    public partial class ModalWindowEditEmployee : Window
    {
        public ModalWindowEditEmployee(Employee employee)
        {
            InitializeComponent();
            var windowService = WindowServiceStorage.Storage;
            DataContext = new ModalWindowEditEmployeeViewModel(windowService, employee);
        }
    }
}
