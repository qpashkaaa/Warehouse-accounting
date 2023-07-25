using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static DependencyProperty TableNameProperty = DependencyProperty.Register(
            "TableName",
            typeof(string),
            typeof(CustomDataGridInfoBox),
            new FrameworkPropertyMetadata(
            null, // default value
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string TableName
        {
            get { return (string)GetValue(TableNameProperty); }
            set { SetValue(TableNameProperty, value); }
        }

        public static DependencyProperty CountTableElementsProperty = DependencyProperty.Register(
            "CountTableElements",
            typeof(int),
            typeof(CustomDataGridInfoBox),
            new FrameworkPropertyMetadata(
            0, // default value
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public int CountTableElements
        {
            get { return (int)GetValue(CountTableElementsProperty); }
            set { SetValue(CountTableElementsProperty, value); }
        }
    }
}
