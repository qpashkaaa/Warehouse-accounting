using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
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
using Warehouse_accounting.Storage;

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomCellDataGridEdit.xaml
    /// </summary>
    public partial class CustomCellDataGridEdit : UserControl
    {
        private ModalWindowEditDataGridRow modalEditWindow;
        public CustomCellDataGridEdit()
        {
            InitializeComponent();
        }

        // id element from database for delete and update his
        private int idElem;
        public int IdElem
        {
            get { return idElem; }
            set
            {
                idElem = value;
            }
        }

        // table id from storage to choose currect open table in view 
        private int openTable;
        public int OpenTable
        {
            get { return openTable; }
            set
            {
                openTable = value;
            }
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            var location = this.PointToScreen(new Point(0, 0));
            modalEditWindow = new ModalWindowEditDataGridRow(IdElem, OpenTable);
            modalEditWindow.Topmost = true;
            modalEditWindow.windowFocus = false;
            modalEditWindow.Left = location.X - (modalEditWindow.Width / 1.13);
            modalEditWindow.Top = location.Y + (modalEditWindow.Height / 2);
            modalEditWindow.Show();
        }

        private async void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            await Task.Delay(10);
            if (modalEditWindow.windowFocus == false)
                modalEditWindow.Close();
        }
    }
}
