using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse_accounting.View.Components;

namespace Warehouse_accounting.ViewModel
{
    public class SidenavViewModel
    {
        private MainWindowViewModel _mainWindowViewModel;
        private UserControl WarehousesDataGridElement;

        public SidenavViewModel()
        {
            WarehousesDataGridElement = new WarehousesDataGridElement();
        }

        // CurrentPage = WarehousesDataGridElement
        /*public ICommand bSidenavCustomWarehousesDataGrid_Click
        {
            get
            {
                return new RelayCommand(() => Trace.WriteLine("WarehousesBtn"));
            }
        }*/
    }
}
