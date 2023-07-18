using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    internal class EmployeesDataGridElementViewModel : ViewModelBase
    {
        private UserControl CustomEmployeesDataGrid;

        private UserControl _currentDataGrid;
        public UserControl CurrentDataGrid
        {
            get { return _currentDataGrid; }
            set { _currentDataGrid = value; RaisePropertyChanged(() => CurrentDataGrid); }
        }

        private double _frameOpacity;
        public double FrameOpacity
        {
            get { return _frameOpacity; }
            set { _frameOpacity = value; RaisePropertyChanged(() => FrameOpacity); }
        }

        public EmployeesDataGridElementViewModel()
        {
            CustomEmployeesDataGrid = new CustomEmployeesDataGrid();
            CurrentDataGrid = CustomEmployeesDataGrid;
            FrameOpacity = 1;
        }

        public ICommand bTabControlEmployeesDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(new CustomEmployeesDataGrid()));
            }
        }

        public ICommand bTabControlEmployeesPositionsDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(new CustomEmployeesPostitionsDataGrid()));
            }
        }

        private async void SlowOpacity(UserControl userControl)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
                CurrentDataGrid = userControl;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }
    }
}
