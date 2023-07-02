using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_accounting.Model.DbModels
{
    public class AccessLevel
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public List<AuthorizationData> AuthorizationDatas { get; set; }
    }
}
