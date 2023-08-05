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
using System.Windows.Shapes;

namespace Warehouse_accounting.View
{
    /// <summary>
    /// Логика взаимодействия для ModalWindowRequestResult.xaml
    /// </summary>
    public partial class ModalWindowRequestResult : Window
    {
        public ModalWindowRequestResult(string message)
        {
            InitializeComponent();
            progress.Width = 0;
            Placeholder = message;
        }

        private string placeholder;
        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                cellPlaceholder.Text = placeholder;
                if (placeholder == "Данные добавлены" || placeholder == "Данные изменены" || placeholder == "Данные удалены")
                {
                    // set colors
                    circle.Background = (Brush)new BrushConverter().ConvertFrom("#12B76A");
                    progressBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#12B76A");
                    cellPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#027A48");

                    // set linear gradient for progress bar
                    LinearGradientBrush gradientBrush = new LinearGradientBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#ECFDF3"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#ECFDF3"), new Point(0.0, 0.0), new Point(1.1, 1.1));
                    progress.Background = gradientBrush;
                }
                else
                {
                    // set color
                    circle.Background = (Brush)new BrushConverter().ConvertFrom("#F15046");
                    progressBorder.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#F15046");
                    cellPlaceholder.Foreground = (Brush)new BrushConverter().ConvertFrom("#F15046");

                    // set linear gradient for progress bar
                    LinearGradientBrush gradientBrush = new LinearGradientBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF2EA"), (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF2EA"), new Point(0.0, 0.0), new Point(1.1, 1.1));
                    progress.Background = gradientBrush;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5);

            int maxValue = 198;
            timer.Tick += (sss, eee) => {
                int match = 0;
                if (progress.Width < maxValue)
                {
                    progress.Width += 2;
                }
                else match++;

                if (match == 1)
                {
                    timer.Stop();
                    this.Close();
                }
            };
            timer.Start();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
