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
    /// Логика взаимодействия для CustomDataGridInfoBox.xaml
    /// </summary>
    public partial class CustomDataGridInfoBox : UserControl
    {
        public CustomDataGridInfoBox()
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
                cellPlaceholder.Text = placeholder;
            }
        }

        private int countElements;
        public int CountElements
        {
            get { return countElements; }
            set
            {
                countElements = value;
                dtGridElementsCount.Text = countElements.ToString();
            }
        }


    }
}
