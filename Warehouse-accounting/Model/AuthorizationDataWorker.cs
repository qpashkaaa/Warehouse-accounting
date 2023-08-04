using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_accounting.Data;
using Warehouse_accounting.Model.DbModels;
using Warehouse_accounting.Storage;

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
        #endregion

        #region CHECK_METHOODS
        public static bool CheckAuthorizationDatas(string login, string password)
        {
            using (AppDbContext db = new AppDbContext())
            {
                bool result = db.AuthorizationDatas.Any(d=>d.Login == login && d.Password == password);
                UserNameStorage.Storage = db.AuthorizationDatas.
                    Where(d => d.Login == login && d.Password == password).
                    Select(d => d.UserName).
                    SingleOrDefault();
                return result;
            }
        }
        #endregion
    }
}
