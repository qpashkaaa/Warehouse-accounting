using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using Warehouse_accounting.Data;
using Warehouse_accounting.Model;

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomComboBox.xaml
    /// </summary>
    public partial class CustomComboBox : UserControl
    {
        TextBlock cbPlaceholder;
        string cbPlaceholderText; 
        public CustomComboBox()
        {
            InitializeComponent();
        }

        public static DependencyProperty ComboBoxItemsProperty = DependencyProperty.Register(
            "ComboBoxItems",
            typeof(List<string>),
            typeof(CustomComboBox),
            new PropertyMetadata(null, new PropertyChangedCallback(PropertyChanged)));

        public List<string> ComboBoxItems
        {
            get { return (List<string>)GetValue(ComboBoxItemsProperty); }
            set { SetValue(ComboBoxItemsProperty, value); }
        }

        private static void PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            CustomComboBox comboBoxElem = (CustomComboBox)obj;
            comboBoxElem.comboBox.ItemsSource = comboBoxElem.ComboBoxItems;
        }

        public static DependencyProperty ComboBoxSelectedItemProperty = DependencyProperty.Register(
            "ComboBoxSelectedItem",
            typeof(string),
            typeof(CustomComboBox),
            new FrameworkPropertyMetadata(
            null, // default value
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string ComboBoxSelectedItem
        {
            get { return (string)GetValue(ComboBoxSelectedItemProperty); }
            set { SetValue(ComboBoxSelectedItemProperty, value); }
        }

        private string placeholder;

        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                cbPlaceholderText = placeholder;
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void cbPlaceholder_Loaded(object sender, RoutedEventArgs e)
        {
            cbPlaceholder = sender as TextBlock;
            cbPlaceholder.Text = cbPlaceholderText;
        }
    }
}
