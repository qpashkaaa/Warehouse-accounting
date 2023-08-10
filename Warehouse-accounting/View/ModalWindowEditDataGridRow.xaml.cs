using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Warehouse_accounting.Storage;
using Warehouse_accounting.ViewModel;

namespace Warehouse_accounting.View
{
    /// <summary>
    /// Логика взаимодействия для ModalWindowEditDataGridRow.xaml
    /// </summary>
    public partial class ModalWindowEditDataGridRow : Window
    {
        public bool windowFocus = false;
        private int IdElem;
        private int OpenTable;

        public ModalWindowEditDataGridRow(int idElem, int openTable)
        {
            InitializeComponent();
            IdElem = idElem;
            OpenTable = openTable;
            var windowService = WindowServiceStorage.Storage;
            DataContext = new ModalWindowEditDataGridRowViewModel(IdElem, OpenTable, windowService);
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            windowFocus = false;
            this.Close();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            windowFocus = true;
        }
    }
}
