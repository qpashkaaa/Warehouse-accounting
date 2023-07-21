using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.View.Components;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Threading;
using Warehouse_accounting.Tools;
using Warehouse_accounting.Storage;

namespace Warehouse_accounting.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IWindowService _windowService;
        private void OnOpenAuthorizationWindow()
        {
            _windowService.OpenAuthorizationWindow();
        }

        public string UserName { get; set; }

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
            UserName = UserNameStorage.Storage;
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

        public ICommand bSidenavExit_Click
        {
            get
            {
                return new RelayCommand(() => OnOpenAuthorizationWindow());
            }
        }

        private async void SlowOpacity(UserControl userControl)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i> 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
                CurrentPage = userControl;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }
    }
}
