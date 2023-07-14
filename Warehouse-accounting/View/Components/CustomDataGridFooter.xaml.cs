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

namespace Warehouse_accounting.View.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomDataGridFooter.xaml
    /// </summary>
    public partial class CustomDataGridFooter : UserControl
    {
        public CustomDataGridFooter()
        {
            InitializeComponent();
        }

        private int activePage;
        public int ActivePage
        {
            get { return activePage; }
            set
            {
                activePage = value;
                btn_1.Active = false;
                btn_2.Active = false;
                btn_3.Active = false;
                btn_4.Active = false;
                btn_5.Active = false;
                btn_6.Active = false;
                btn_7.Active = false;

                if (countPages == 1)
                {
                    if (activePage == 1)
                        btn_4.Active = true;
                }
                else if (countPages == 2)
                {
                    if (activePage == 1)
                        btn_3.Active = true;
                    else if (activePage == 2)
                        btn_5.Active = true;
                }
                else if (countPages == 3)
                {
                    if (activePage == 1)
                        btn_3.Active = true;
                    else if (activePage == 2)
                        btn_4.Active = true;
                    else if (activePage == 3)
                        btn_5.Active = true;
                }
                else if (countPages == 4)
                {
                    if (activePage == 1)
                        btn_2.Active = true;
                    else if (activePage == 2)
                        btn_3.Active = true;
                    else if (activePage == 3)
                        btn_5.Active = true;
                    else if (activePage == 4)
                        btn_6.Active = true;
                }
                else if (countPages == 5)
                {
                    if (activePage == 1)
                        btn_2.Active = true;
                    else if (activePage == 2)
                        btn_3.Active = true;
                    else if (activePage == 3)
                        btn_4.Active = true;
                    else if (activePage == 4)
                        btn_5.Active = true;
                    else if (activePage == 5)
                        btn_6.Active = true;
                }
                else if (countPages == 6)
                {
                    if (activePage == 1)
                        btn_1.Active = true;
                    else if (activePage == 2)
                        btn_2.Active = true;
                    else if (activePage == 3)
                        btn_3.Active = true;
                    else if (activePage == 4)
                        btn_5.Active = true;
                    else if (activePage == 5)
                        btn_6.Active = true;
                    else if (activePage == 6)
                        btn_7.Active = true;
                }
                else if (countPages == 7)
                {
                    if (activePage == 1)
                        btn_1.Active = true;
                    else if (activePage == 2)
                        btn_2.Active = true;
                    else if (activePage == 3)
                        btn_3.Active = true;
                    else if (activePage == 4)
                        btn_4.Active = true;
                    else if (activePage == 5)
                        btn_5.Active = true;
                    else if (activePage == 6)
                        btn_6.Active = true;
                    else if (activePage == 7)
                        btn_7.Active = true;
                }
                else if (countPages - activePage <= 6){
                    btn_1.Placeholder = (countPages - 6).ToString();
                    btn_2.Placeholder = (countPages - 5).ToString();
                    btn_3.Placeholder = (countPages - 4).ToString();
                    btn_4.Placeholder = (countPages - 3).ToString();
                    btn_5.Placeholder = (countPages - 2).ToString();
                    btn_6.Placeholder = (countPages - 1).ToString();
                    btn_7.Placeholder = (countPages).ToString();
                    if (activePage == countPages - 6)
                        btn_1.Active = true;
                    else if (activePage == countPages - 5)
                        btn_2.Active = true;
                    else if (activePage == countPages - 4)
                        btn_3.Active = true;
                    else if (activePage == countPages - 3)
                        btn_4.Active = true;
                    else if (activePage == countPages - 2)
                        btn_5.Active = true;
                    else if (activePage == countPages - 1)
                        btn_6.Active = true;
                    else if (activePage == countPages)
                        btn_7.Active = true;
                }
                else
                {
                    btn_4.Placeholder = "...";
                    if (activePage == 1)
                        btn_1.Active = true;
                    else if (activePage == 2)
                        btn_2.Active = true;
                    else if (activePage == 3)
                        btn_3.Active = true;
                    else if (activePage == countPages - 2)
                        btn_5.Active = true;
                    else if (activePage == countPages - 1)
                        btn_6.Active = true;
                    else if (activePage == countPages)
                        btn_7.Active = true;
                    else
                    {
                        btn_1.Active = true;
                        btn_1.Placeholder = activePage.ToString();
                        btn_2.Placeholder = (activePage + 1).ToString();
                        btn_3.Placeholder = (activePage + 2).ToString();
                    }
                }
            }
        }

        private int countPages;
        public int CountPages
        {
            get { return countPages; }
            set
            {
                countPages = value;

                if (countPages == 1)
                {
                    btn_4.Placeholder = "1";
                }
                else if (countPages == 2)
                {
                    btn_3.Placeholder = "1";
                    btn_4.Placeholder = "...";
                    btn_5.Placeholder = "2";
                }
                else if (countPages == 3)
                {
                    btn_3.Placeholder = "1";
                    btn_4.Placeholder = "2";
                    btn_5.Placeholder = "3";
                }
                else if (countPages == 4)
                {
                    btn_2.Placeholder = "1";
                    btn_3.Placeholder = "2";
                    btn_4.Placeholder = "...";
                    btn_5.Placeholder = "3";
                    btn_6.Placeholder = "4";
                }
                else if (countPages == 5)
                {
                    btn_2.Placeholder = "1";
                    btn_3.Placeholder = "2";
                    btn_4.Placeholder = "3";
                    btn_5.Placeholder = "4";
                    btn_6.Placeholder = "5";
                }
                else if (countPages == 6)
                {
                    btn_1.Placeholder = "1";
                    btn_2.Placeholder = "2";
                    btn_3.Placeholder = "3";
                    btn_4.Placeholder = "...";
                    btn_5.Placeholder = "4";
                    btn_6.Placeholder = "5";
                    btn_7.Placeholder = "6";
                }
                else if (countPages == 7)
                {
                    btn_1.Placeholder = "1";
                    btn_2.Placeholder = "2";
                    btn_3.Placeholder = "3";
                    btn_4.Placeholder = "4";
                    btn_5.Placeholder = "5";
                    btn_6.Placeholder = "6";
                    btn_7.Placeholder = "7";
                }
                else
                {
                    btn_1.Placeholder = "1";
                    btn_2.Placeholder = "2";
                    btn_3.Placeholder = "3";
                    btn_4.Placeholder = "...";
                    btn_5.Placeholder = (countPages - 2).ToString();
                    btn_6.Placeholder = (countPages - 1).ToString();
                    btn_7.Placeholder = (countPages).ToString();
                }
            }
        }
    }
}
