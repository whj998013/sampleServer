using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
using SG.Model.Sys;
using SampleDataOper;
namespace SysBLL
{
    public class PermissionOper
    {
        public List<IPermission> GetList()
        {
            List<IPermission> list = new List<IPermission>();
            var re = new SunginDataContext().Permissions.OrderBy(p=>p.Key).ToList();
            list.AddRange(re);
            return list;
        }
     
    }
}
