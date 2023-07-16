using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.View.Components;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        public MainWindowViewModel()
        {

        }

        public ICommand bSidenavCustomWarehousesDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = new WarehousesDataGridElement());
            }
        }
    }
}
