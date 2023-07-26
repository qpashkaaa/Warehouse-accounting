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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Warehouse_accounting.Model.DbModels;

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomWarehousesDataGrid.xaml
    /// </summary>
    public partial class CustomWarehousesDataGrid : UserControl
    {
        private const int countRows = 7;
        public CustomWarehousesDataGrid(List<Warehouse> dataGridList, int countTableElements, int activePage)
        {
            InitializeComponent();
            double countPages = Math.Ceiling((double)countTableElements / countRows);
            this.Footer.CountPages = Convert.ToInt32(countPages);
            this.Footer.ActivePage = activePage;
            AddData(dataGridList);
        }

        private void AddData(List<Warehouse> dataGridList)
        {
            for (int i = 1; i < dataGridList.Count + 1; i++)
            {
                try
                {
                    CustomCellDataGridMainInfo mainInfo = new CustomCellDataGridMainInfo();
                    CustomCellDataGridID idElem = new CustomCellDataGridID();
                    CustomCellDataGridTextInfo textInfo = new CustomCellDataGridTextInfo();
                    CustomCellDataGridStatus statusElem = new CustomCellDataGridStatus();
                    CustomCellDataGridEdit editElem = new CustomCellDataGridEdit();
                    Warehouse listElem = dataGridList[i - 1];

                    mainInfo.Placeholder = listElem.Name;
                    grid.Children.Add(mainInfo);
                    Grid.SetColumn(mainInfo, 0);
                    Grid.SetRow(mainInfo, i);

                    idElem.Placeholder = listElem.UniqueNumber;
                    grid.Children.Add(idElem);
                    Grid.SetColumn(idElem, 1);
                    Grid.SetRow(idElem, i);

                    textInfo.Placeholder = listElem.WarehouseAddress.Street + ", " + listElem.WarehouseAddress.HouseNumber;
                    textInfo.OptPlaceholder = listElem.WarehouseAddress.City;
                    grid.Children.Add(textInfo);
                    Grid.SetColumn(textInfo, 2);
                    Grid.SetRow(textInfo, i);

                    statusElem.Placeholder = listElem.WarehouseStatus.Status;
                    grid.Children.Add(statusElem);
                    Grid.SetColumn(statusElem, 3);
                    Grid.SetRow(statusElem, i);

                    grid.Children.Add(editElem);
                    Grid.SetColumn(editElem, 4);
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
