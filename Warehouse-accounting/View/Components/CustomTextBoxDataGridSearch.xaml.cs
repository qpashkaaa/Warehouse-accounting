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
    /// Логика взаимодействия для CustomTextBoxDataGridSearch.xaml
    /// </summary>
    public partial class CustomTextBoxDataGridSearch : UserControl
    {
        public CustomTextBoxDataGridSearch()
        {
            InitializeComponent();
        }

        public static DependencyProperty CustomSearchTextBoxTextProperty = DependencyProperty.Register(
            "CustomSearchTextBoxText",
            typeof(string),
            typeof(CustomTextBoxDataGridSearch),
            new FrameworkPropertyMetadata(
            null, // default value
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string CustomSearchTextBoxText
        {
            get { return (string)GetValue(CustomSearchTextBoxTextProperty); }
            set { SetValue(CustomSearchTextBoxTextProperty, value); }
        }

        private string placeholder;

        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                tbPlaceholder.Text = placeholder;
            }
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                tbPlaceholder.Visibility = Visibility.Visible;
            else
                tbPlaceholder.Visibility = Visibility.Hidden;
        }
    }
}
