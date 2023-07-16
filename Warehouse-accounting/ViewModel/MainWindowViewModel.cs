using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.View;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private UserControl _currentPage;
        public UserControl CurrentPage 
        {
            get { return _currentPage; }
            set { _currentPage = value; RaisePropertyChanged(() => CurrentPage); }
        }
    }
}
