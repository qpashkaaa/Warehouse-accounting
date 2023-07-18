using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.View.Components;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Threading;

namespace Warehouse_accounting.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserControl _currentPage;
        public UserControl CurrentPage 
        {
            get { return _currentPage; }
            set { _currentPage = value; RaisePropertyChanged(() => CurrentPage); }
        }

        private double _frameOpacity;
        public double FrameOpacity
        {
            get { return _frameOpacity; }
            set { _frameOpacity = value; RaisePropertyChanged(() => FrameOpacity); }
        }

        public MainWindowViewModel()
        {
            FrameOpacity = 1;
        }

        public ICommand bSidenavWarehousesDataGridElement_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(new WarehousesDataGridElement()));
            }
        }

        public ICommand bSidenavEmployeesDataGridElement_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(new EmployeesDataGridElement()));
            }
        }

        private async void SlowOpacity(UserControl userControl)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i> 0.0; i -= 0.07)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = userControl;
                for (double i = 0.0; i < 1.1; i += 0.07)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }
    }
}
