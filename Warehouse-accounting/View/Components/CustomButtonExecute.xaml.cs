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
    /// Логика взаимодействия для CustomButtonExecute.xaml
    /// </summary>
    public partial class CustomButtonExecute : UserControl
    {
        public CustomButtonExecute()
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

        private System.Windows.Media.Brush color;

        public System.Windows.Media.Brush Color
        {
            get { return color; }
            set
            {
                color = value;
                btnStyle.Background = color;
            }
        }
    }
}
