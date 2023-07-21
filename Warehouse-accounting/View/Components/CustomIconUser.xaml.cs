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
    /// Логика взаимодействия для CustomIconUser.xaml
    /// </summary>
    public partial class CustomIconUser : UserControl
    {
        public CustomIconUser()
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
                if (placeholder.Length != 2)
                {
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
                    icnPlaceholder.Text = iconShortName;
                }
                else
                {
                    icnPlaceholder.Text = placeholder;
                }
            }
        }
    }
}
