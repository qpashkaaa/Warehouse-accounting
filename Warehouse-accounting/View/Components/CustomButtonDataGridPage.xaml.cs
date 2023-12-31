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
    /// Логика взаимодействия для CustomButtonDataGridPage.xaml
    /// </summary>
    public partial class CustomButtonDataGridPage : UserControl
    {
        public CustomButtonDataGridPage()
        {
            InitializeComponent();
        }

        private string placeholder;
        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                btnPlaceholder.Text = placeholder;
            }
        }

        private bool active;
        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
                if (active == true)
                {
                    btnStyle.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#D0D5DD");
                    btnStyle.Background = (Brush)new BrushConverter().ConvertFrom("#EFF1F4");
                    btnPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#091E42");
                }
            }
        }
    }
}
