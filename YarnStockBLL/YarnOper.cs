using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageData;

namespace YarnStockBLL
{
    public class YarnOper
    {
        public static List<LocalProductView> GetYarnList(out int Count,Func<LocalProductView, bool> whereLambda, Func<LocalProductView, object> orderbyLamba, int PageId, int PageSize)
        {
            YarnStockContext ysc = new YarnStockContext();
            Count = ysc.LocalProductView.Where(whereLambda).Count();
            List<LocalProductView> list = ysc.LocalProductView.Where(whereLambda).OrderBy(orderbyLamba).ThenBy(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }
        public static List<LocalProductView> GetYarnListDesc(out int Count, Func<LocalProductView, bool> whereLambda, Func<LocalProductView, object> orderbyLamba, int PageId , int PageSize)
        {
            YarnStockContext ysc = new YarnStockContext();
            Count = ysc.LocalProductView.Where(whereLambda).Count();
            List<LocalProductView> list = ysc.LocalProductView.Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }

        public static List<LocalProductView> GetYarnListDesc(out int Count, Func<LocalProductView, bool> whereLambda, Func<LocalProductView, object> orderbyLamba)
        {
            YarnStockContext ysc = new YarnStockContext();
            Count = ysc.LocalProductView.Where(whereLambda).Count();
            List<LocalProductView> list = ysc.LocalProductView.Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.ID).ToList();
            return list;
        }

        public static List<OutStorageView> GetOutView(string batchnum)
        {
            YarnStockContext ysc = new YarnStockContext();
            return ysc.OutStorageView.Where(p => p.BatchNum == batchnum).ToList();
        }
    }
}
