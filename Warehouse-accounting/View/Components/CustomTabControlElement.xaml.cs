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
using Warehouse_accounting.Storage.Components;

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
            CustomTabControlElementStorage.Storage.Add(this);
        }
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

        private void btnStyle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (CustomTabControlElement btn in CustomTabControlElementStorage.Storage)
            {
                setUnactive(btn);
            }
            setActive();
        }

        private void setActive()
        {
            brdColor.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#6A1039");
            brdColor.BorderThickness = new Thickness(0, 0, 0, 2);
            elemPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#6A1039");
        }

        private void setUnactive(CustomTabControlElement _btn)
        {
            _btn.brdColor.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#EAECF0");
            _btn.brdColor.BorderThickness = new Thickness(0, 0, 0, 1);
            _btn.elemPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#667085");
        }
    }
}
