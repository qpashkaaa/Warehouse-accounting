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
    /// Логика взаимодействия для CustomDataGridTabControl.xaml
    /// </summary>
    public partial class CustomDataGridTabControl : UserControl
    {
        public CustomDataGridTabControl()
        {
            InitializeComponent();
        }

        private int activeTab;
        public int ActiveTab
        {
            get { return activeTab; }
            set
            {
                activeTab = value;
                if (activeTab == 1)
                    t_1.Active = true;
                else if (activeTab == 2)
                    t_2.Active = true;
                else if (activeTab == 3)
                    t_3.Active = true;
                else if (activeTab == 4)
                    t_4.Active = true;
                else if (activeTab == 5)
                    t_5.Active = true;
                else if (activeTab == 6)
                    t_6.Active = true;
                else if (activeTab == 7)
                    t_7.Active = true;
                else if (activeTab == 8)
                    t_8.Active = true;
                else if (activeTab == 9)
                    t_9.Active = true;
            }
        }

        private string elem_1;
        public string T_1
        {
            get { return elem_1; }
            set
            {
                elem_1 = value;
                t_1.Placeholder = elem_1;
            }
        }

        private string elem_2;
        public string T_2
        {
            get { return elem_2; }
            set
            {
                elem_2 = value;
                t_2.Placeholder = elem_2;
            }
        }

        private string elem_3;
        public string T_3
        {
            get { return elem_3; }
            set
            {
                elem_3 = value;
                t_3.Placeholder = elem_3;
            }
        }

        private string elem_4;
        public string T_4
        {
            get { return elem_4; }
            set
            {
                elem_4 = value;
                t_4.Placeholder = elem_4;
            }
        }

        private string elem_5;
        public string T_5
        {
            get { return elem_5; }
            set
            {
                elem_5 = value;
                t_5.Placeholder = elem_5;
            }
        }

        private string elem_6;
        public string T_6
        {
            get { return elem_6; }
            set
            {
                elem_6 = value;
                t_6.Placeholder = elem_6;
            }
        }

        private string elem_7;
        public string T_7
        {
            get { return elem_7; }
            set
            {
                elem_7 = value;
                t_7.Placeholder = elem_7;
            }
        }

        private string elem_8;
        public string T_8
        {
            get { return elem_8; }
            set
            {
                elem_8 = value;
                t_8.Placeholder = elem_8;
            }
        }

        private string elem_9;
        public string T_9
        {
            get { return elem_9; }
            set
            {
                elem_9 = value;
                t_9.Placeholder = elem_9;
            }
        }
    }
}
