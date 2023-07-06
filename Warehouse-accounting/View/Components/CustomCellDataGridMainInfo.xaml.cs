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
    /// Логика взаимодействия для CustomCellDataGridMainInfo.xaml
    /// </summary>
    public partial class CustomCellDataGridMainInfo : UserControl
    {
        public CustomCellDataGridMainInfo()
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
                string iconShortName;
                string[] name = placeholder.Split(' ');
                if (name.Length > 1)
                {
                    iconShortName = name[0][0].ToString().ToUpper() + name[1][0].ToString().ToUpper();
                }
                else
                {
                    iconShortName = name[0][0].ToString().ToUpper();
                }
                elemIconShortName.Placeholder = iconShortName;
            }
        }
    }
}
