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
    /// Логика взаимодействия для CustomButtonSidenav.xaml
    /// </summary>
    public partial class CustomButtonSidenav : UserControl
    {
        public CustomButtonSidenav()
        {
            InitializeComponent();
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
                    btnStyle.Background = (Brush)new BrushConverter().ConvertFrom("#9A4C1E");
                    btnPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#F7E8EF");
                    selectedBtnImg.Visibility = Visibility.Visible;

                    string imgFileName = System.IO.Path.GetFileName(btnImage.Source.ToString());
                    imgFileName = imgFileName.Substring(0, imgFileName.IndexOf('.'));
                    btnImage.Source = new BitmapImage(new Uri($"/Images/{imgFileName}_Selected.png", UriKind.Relative));
                }
            }
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

        private string imageName;
        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                btnImage.Source = new BitmapImage(new Uri($"/Images/{imageName}.png", UriKind.Relative));
            }
        }
    }
}
