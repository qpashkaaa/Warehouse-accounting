using System;
using System.Collections.Generic;
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
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.Storage;

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomEmployeesPostitionsDataGrid.xaml
    /// </summary>
    public partial class CustomEmployeesPostitionsDataGrid : UserControl
    {
        private const int countRows = 7;
        public CustomEmployeesPostitionsDataGrid(List<EmployeePosition> dataGridList, int countTableElements, int activePage)
        {
            InitializeComponent();
            double countPages = 1;
            if (countTableElements != 0)
            {
                countPages = Math.Ceiling((double)countTableElements / countRows);
            }
            this.Footer.CountPages = Convert.ToInt32(countPages);
            this.Footer.ActivePage = activePage;
            AddData(dataGridList);
        }

        private void AddData(List<EmployeePosition> dataGridList)
        {
            for (int i = 1; i < dataGridList.Count + 1; i++)
            {
                CustomCellDataGridMainInfo mainInfo = new CustomCellDataGridMainInfo();
                CustomCellDataGridEdit editElem = new CustomCellDataGridEdit();
                try
                {
                    mainInfo.Placeholder = dataGridList[i - 1].Position;
                    grid.Children.Add(mainInfo);
                    Grid.SetColumn(mainInfo, 0);
                    Grid.SetRow(mainInfo, i);

                    editElem.IdElem = dataGridList[i - 1].Id;
                    editElem.OpenTable = TablesIdStorage.EMPLOYEES_POSITIONS_TABLE;
                    grid.Children.Add(editElem);
                    Grid.SetColumn(editElem, 1);
                    Grid.SetRow(editElem, i);
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
