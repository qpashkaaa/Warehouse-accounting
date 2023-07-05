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
    /// Логика взаимодействия для CustomCellDataGridStatus.xaml
    /// </summary>
    public partial class CustomCellDataGridStatus : UserControl
    {
        public CustomCellDataGridStatus()
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
                if (placeholder == "Открыт" || placeholder == "В сети")
                {
                    elemStyle.Background = (Brush)new BrushConverter().ConvertFrom("#ECFDF3");
                    circle.Background = (Brush)new BrushConverter().ConvertFrom("#12B76A");
                    cellPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#027A48");
                }
                else
                {
                    elemStyle.Background = (Brush)new BrushConverter().ConvertFrom("#FFF2EA");
                    circle.Background = (Brush)new BrushConverter().ConvertFrom("#F15046");
                    cellPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#F15046");
                }
            }
        }
    }
}
