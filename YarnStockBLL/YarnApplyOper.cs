using SunginData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.DdApi;
using SG.DdApi.Approve;

namespace YarnStockBLL
{
    public class YarnApplyOper
    {
        public static void DeleteYarnApply(string ApplyNo,string Uname)
        {
            using SunginDataContext sdc = new SunginDataContext();

            var apply = sdc.YarnOutApplies.SingleOrDefault(p => p.NO == ApplyNo);
            if (apply != null&&apply.Stats!=SG.Model.ApplyState.已出库&&apply.Stats!=SG.Model.ApplyState.通过)
            {
                apply.Delete(Uname);
                sdc.SaveChanges();
            }

        }
    }
}
