using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Warehouse_accounting.Data;

namespace Warehouse_accounting
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new Thread(() => {
                using (AppDbContext db = new AppDbContext())
                {
                    db.AuthorizationDatas.FirstOrDefault();
                }
            }).Start();
        }
    }
}
