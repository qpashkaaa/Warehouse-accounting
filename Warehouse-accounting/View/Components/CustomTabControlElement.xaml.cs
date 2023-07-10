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
    /// Логика взаимодействия для CustomTabControlElement.xaml
    /// </summary>
    public partial class CustomTabControlElement : UserControl
    {
        public CustomTabControlElement()
        {
            InitializeComponent();
        }

        // cellPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#F15046");
        private string placeholder;
        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                elemPlaceholder.Text = placeholder;
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
                    brdColor.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#6A1039");
                    brdColor.BorderThickness = new Thickness(0, 0, 0, 2);
                    elemPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#6A1039");
                }
            }
        }
    }
}
