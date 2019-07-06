using SG.Model.Sys;
using StorageData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnStockBLL
{
    public class MyYarn
    {
        User _user { get; set; } 
        YarnStockContext ysc { get; set; } = new YarnStockContext();
        public MyYarn(User u)
        {
            _user = u;
        }
      

        public  List<InOrderView> GetMyInStockYarnList(out int Count, Func<InOrderView, bool> whereLambda, Func<InOrderView, object> orderbyLamba, int PageId, int PageSize)
        {
            YarnStockContext ysc = new YarnStockContext();
            Count = ysc.InOrderView.Where(p => p.UserID == _user.DdId).Where(whereLambda).Count();
            List<InOrderView> list = ysc.InOrderView.Where(whereLambda).OrderBy(orderbyLamba).ThenBy(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }


        public  List<InOrderView> GetMyInStockYarnListDesc(out int Count, Func<InOrderView, bool> whereLambda, Func<InOrderView, object> orderbyLamba, int PageId, int PageSize)
        {
            YarnStockContext ysc = new YarnStockContext();
            Count = ysc.InOrderView.Where(whereLambda).Count();
            List<InOrderView> list = ysc.InOrderView.Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }


        public List<OutStorageView> GetMyOutStockYarnList(out int Count, Func<OutStorageView, bool> whereLambda, Func<OutStorageView, object> orderbyLamba, int PageId, int PageSize)
        {
            YarnStockContext ysc = new YarnStockContext();
            Count = ysc.OutStorageView.Where(whereLambda).Count();
            List<OutStorageView> list = ysc.OutStorageView.Where(p => p.OutUid == _user.DdId).Where(whereLambda).OrderBy(orderbyLamba).ThenBy(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }


        public List<OutStorageView> GetMyOutStockYarnListDesc(out int Count, Func<OutStorageView, bool> whereLambda, Func<OutStorageView, object> orderbyLamba, int PageId, int PageSize)
        {
            YarnStockContext ysc = new YarnStockContext();
            Count = ysc.OutStorageView.Where(whereLambda).Count();
            List<OutStorageView> list = ysc.OutStorageView.Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.ID).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();

            return list;
        }

    }
}
