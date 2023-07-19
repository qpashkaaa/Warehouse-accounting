using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_accounting.Data;
using Warehouse_accounting.Model.DbModels;

namespace Warehouse_accounting.Model
{
    public static class AuthorizationDataWorker
    {
        #region GET_METHOODS
        public static List<AuthorizationData> GetAuthorizationDatas()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.AuthorizationDatas.ToList();
                return result;
            }
        }

        public static bool CheckAuthorizationDatas(string login, string password)
        {
            using (AppDbContext db = new AppDbContext())
            {
                bool result = db.AuthorizationDatas.Any(d=>d.Login == login && d.Password == password);
                return result;
            }
        }
        #endregion
    }
}
