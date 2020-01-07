using SG.Model.Sys;
using StorageData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Yarn;
using SunginData;
namespace YarnStockBLL
{
    public class MyYarn
    {
        User _user { get; set; }
        public MyYarn(User u)
        {
            _user = u;
        }

        public static void YarnOutApplyStatsUpdate()
        {
            using YarnStockContext ysc = new YarnStockContext();
            using SunginDataContext sdc = new SunginDataContext();
            sdc.YarnOutApplies.Where(t => t.Stats == SG.Model.ApplyState.通过&&!t.IsDelete).ToList().ForEach(p =>
               {
                   var os = ysc.OutStorage.FirstOrDefault(o => o.OrderNum == p.OrderNum && o.IsDelete == 0);
                   if (os != null)
                   {
                       if (os.Status == 2) p.Stats = SG.Model.ApplyState.已出库;
                       else if (os.Status == 1) { }
                       else p.Stats = SG.Model.ApplyState.仓库审核不通过;
                   }
                   else
                   {
                       ///已删除出库单
                       p.Stats = SG.Model.ApplyState.仓库审核不通过;
                   }
               });
            sdc.SaveChanges();

        }
        public List<YarnOutApply> GetMyOutApplyList(out int Count, Func<YarnOutApply, bool> whereLambda, Func<YarnOutApply, object> orderbyLamba, int PageId, int PageSize)
        {
            using SunginDataContext sdc = new SunginDataContext();
            Count = sdc.YarnOutApplies.Where(p => p.ApplyEmpDdid == _user.DdId).Where(whereLambda).Count();
            List<YarnOutApply> list = sdc.YarnOutApplies.AsNoTracking().Where(whereLambda).OrderBy(orderbyLamba).ThenBy(p => p.Id).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;

        }
        public List<YarnOutApply> GetMyOutApplyListDesc(out int Count, Func<YarnOutApply, bool> whereLambda, Func<YarnOutApply, object> orderbyLamba, int PageId, int PageSize)
        {

            using SunginDataContext sdc = new SunginDataContext();
            Count = sdc.YarnOutApplies.Where(p => p.ApplyEmpDdid == _user.DdId).Where(whereLambda).Count();
            List<YarnOutApply> list = sdc.YarnOutApplies.AsNoTracking().Where(whereLambda).OrderByDescending(orderbyLamba).OrderByDescending(p => p.Id).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;

        }

        public List<InOrderView> GetMyInStockYarnList(out int Count, Func<InOrderView, bool> whereLambda, Func<InOrderView, object> orderbyLamba, int PageId, int PageSize)
        {
            using YarnStockContext ysc = new YarnStockContext();
            Count = ysc.InOrderView.Where(p => p.UserID == _user.DdId).Where(whereLambda).Count();
            List<InOrderView> list = ysc.InOrderView.AsNoTracking().Where(whereLambda).OrderBy(orderbyLamba).ThenBy(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }


        public List<InOrderView> GetMyInStockYarnListDesc(out int Count, Func<InOrderView, bool> whereLambda, Func<InOrderView, object> orderbyLamba, int PageId, int PageSize)
        {
            using YarnStockContext ysc = new YarnStockContext();
            Count = ysc.InOrderView.Where(whereLambda).Count();
            List<InOrderView> list = ysc.InOrderView.AsNoTracking().Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }


        public List<OutStorageView> GetMyOutStockYarnList(out int Count, Func<OutStorageView, bool> whereLambda, Func<OutStorageView, object> orderbyLamba, int PageId, int PageSize)
        {
            using YarnStockContext ysc = new YarnStockContext();
            Count = ysc.OutStorageView.Where(whereLambda).Count();
            List<OutStorageView> list = ysc.OutStorageView.AsNoTracking().Where(p => p.OutUid == _user.DdId).Where(whereLambda).OrderBy(orderbyLamba).ThenBy(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }


        public List<OutStorageView> GetMyOutStockYarnListDesc(out int Count, Func<OutStorageView, bool> whereLambda, Func<OutStorageView, object> orderbyLamba, int PageId, int PageSize)
        {
            using YarnStockContext ysc = new YarnStockContext();
            Count = ysc.OutStorageView.Where(whereLambda).Count();
            List<OutStorageView> list = ysc.OutStorageView.AsNoTracking().Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();

            return list;
        }

    }
}
