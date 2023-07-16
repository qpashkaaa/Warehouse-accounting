using System;
using System.Collections.Generic;
using System.Data;
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
using Warehouse_accounting.ViewStorage.Components;

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
            CustomButtonSidenavStorage.Storage.Add(this);
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

        private void btnStyle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (CustomButtonSidenav btn in CustomButtonSidenavStorage.Storage)
            {
                setUnactive(btn);
            }

            if (selectedBtnImg.Visibility == Visibility.Hidden)
            {
                setActive();
            }
        }

        private void setActive()
        {
            btnStyle.Background = (Brush)new BrushConverter().ConvertFrom("#9A4C1E");
            btnPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#F7E8EF");
            selectedBtnImg.Visibility = Visibility.Visible;

            string imgFileName = System.IO.Path.GetFileName(btnImage.Source.ToString());
            imgFileName = imgFileName.Substring(0, imgFileName.IndexOf('.'));
            btnImage.Source = new BitmapImage(new Uri($"/Images/{imgFileName}_Selected.png", UriKind.Relative));
        }

        private void setUnactive(CustomButtonSidenav _btn)
        {
            _btn.btnStyle.Background = (Brush)new BrushConverter().ConvertFrom("#FFFFFF");
            _btn.btnPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#091E42");
            _btn.selectedBtnImg.Visibility = Visibility.Hidden;

            string imgFileName = System.IO.Path.GetFileName(_btn.btnImage.Source.ToString());
            imgFileName = imgFileName.Substring(0, imgFileName.IndexOf('.'));
            if (imgFileName.Substring(imgFileName.IndexOf('_') + 1) == "Selected")
            {
                imgFileName = imgFileName.Substring(0, imgFileName.IndexOf('_'));
                _btn.btnImage.Source = new BitmapImage(new Uri($"/Images/{imgFileName}.png", UriKind.Relative));
            }
        }
    }
}
