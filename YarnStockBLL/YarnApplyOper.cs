using SunginData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.DdApi;
using SG.DdApi.Approve;
using StorageData;


namespace YarnStockBLL
{
    public class YarnApplyOper
    {
        public static void DeleteYarnApply(string ApplyNo, string Uname)
        {
            using SunginDataContext sdc = new SunginDataContext();

            var apply = sdc.YarnOutApplies.SingleOrDefault(p => p.NO == ApplyNo);
            if (apply != null && apply.Stats != SG.Model.ApplyState.已出库 && apply.Stats != SG.Model.ApplyState.通过)
            {
                apply.Delete(Uname);
                sdc.SaveChanges();
            }

        }

        public static SG.Model.Yarn.YarnOutApply AlowYarnApply(string ApplyNo, double OutNum = 0, double OutPrice = 0)
        {

            using SunginDataContext sdc = new SunginDataContext();
            var yoa = sdc.YarnOutApplies.FirstOrDefault(p => p.NO == ApplyNo);
            if (!(yoa.Stats == SG.Model.ApplyState.已出库||yoa.Stats==SG.Model.ApplyState.通过))
            {
                yoa.Stats = SG.Model.ApplyState.通过;
                double rNum = OutNum;
                if (rNum <= 0 || rNum > yoa.LocalNum) rNum = yoa.MinNum;
                yoa.Num = rNum;
                yoa.OutPrice = OutPrice;
                yoa.Stats = SG.Model.ApplyState.通过;
                yoa.Amount = Math.Round(yoa.OutPrice * yoa.Num, 1);
                //生成出库单
                NewYarnOutStock nyos = new NewYarnOutStock();
                nyos.AddYarnOutStock(yoa);
                sdc.SaveChanges();
            }
            return yoa;
        }
    }
}
