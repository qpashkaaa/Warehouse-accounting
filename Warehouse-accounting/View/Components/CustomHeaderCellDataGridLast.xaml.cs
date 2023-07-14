using System;
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
    /// Логика взаимодействия для CustomHeaderCellDataGridLast.xaml
    /// </summary>
    public partial class CustomHeaderCellDataGridLast : UserControl
    {
        public CustomHeaderCellDataGridLast()
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

        private double width;
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
                brdSettings.Width = width;
            }
        }
    }
}
