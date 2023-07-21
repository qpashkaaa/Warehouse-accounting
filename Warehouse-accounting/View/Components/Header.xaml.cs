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
    /// Логика взаимодействия для Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        public static DependencyProperty IconUserNamePlaceholderProperty = DependencyProperty.Register(
            "IconUserNamePlaceholder",
            typeof(string),
            typeof(Header),
            new PropertyMetadata(null, new PropertyChangedCallback(PropertyChanged)));

        public string IconUserNamePlaceholder
        {
            get { return (string)GetValue(IconUserNamePlaceholderProperty); }
            set { SetValue(IconUserNamePlaceholderProperty, value); }
        }


        private static void PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Header header = (Header)obj;
            header.UserIcon.Placeholder = header.IconUserNamePlaceholder;
        }
    }
}
