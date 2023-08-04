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
    /// Логика взаимодействия для CustomTextBoxReadOnly.xaml
    /// </summary>
    public partial class CustomTextBoxReadOnly : UserControl
    {
        public CustomTextBoxReadOnly()
        {
            InitializeComponent();
        }

        public static DependencyProperty CustomTextBoxTextProperty = DependencyProperty.Register(
            "CustomTextBoxText",
            typeof(string),
            typeof(CustomTextBoxReadOnly),
            new FrameworkPropertyMetadata(
            null, // default value
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string CustomTextBoxText
        {
            get { return (string)GetValue(CustomTextBoxTextProperty); }
            set { SetValue(CustomTextBoxTextProperty, value); }
        }
    }
}
