using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataOper.Model;
using SG.Utilities;
using SampleBLL;

namespace SampleDataOper
{
    public class SampleOper
    {
        public static object GetPrintSample(string styleId)
        {
            using (SampleContext sc = new SampleContext())
            {
                SampleBaseInfo s = sc.SampleBaseInfos.SingleOrDefault(p => p.StyleId == styleId);
                if (s != null)
                {
                    var re = SampleHelper.GetEditObj(s);
                    return new { re.PicList, re.StyleId,re.StyleNo, re.Material, re.HaveStock, re.CanLendOut,re.SalePrice,re.Counts };
                }
                else return null;

            }

        }
        public static object GetSample(string styleId)
        {
            using (SampleContext sc = new SampleContext())
            {
                SampleBaseInfo s = sc.SampleBaseInfos.SingleOrDefault(p => p.StyleId == styleId);
                if (s != null)
                {

                    return SampleHelper.GetEditObj(s);
                    
                }
                else return null;

            }
        }

        public static SampleBaseInfo DeleteSample(string styleId, string user)
        {
            using (SampleContext sc = new SampleContext())
            {
                SampleBaseInfo s = sc.SampleBaseInfos.FirstOrDefault(p => p.StyleId == styleId);
                if (s != null)
                {
                    s.Delete(user);
                    sc.SaveChanges();
                    return s;
                }
                else return null;
            }
        }
        public static SampleBaseInfo AcceptInStorage(string styleId)
        {
            using (SampleContext sc = new SampleContext())
            {
                SampleBaseInfo s = sc.SampleBaseInfos.FirstOrDefault(p => p.StyleId == styleId);
                if (s != null)
                {
                    s.State = SampleState.在库;
                    sc.SaveChanges();
                    return s;
                }
                else return null;
            }
        }

        /// <summary>
        /// 直接入库
        /// </summary>
        /// <param name="styleId"></param>
        /// <returns></returns>
        public static SampleBaseInfo PutInStorage(string styleId)
        {
            using (SampleContext sc = new SampleContext())
            {
                SampleBaseInfo s = sc.SampleBaseInfos.FirstOrDefault(p => p.StyleId == styleId);
                if (s != null)
                {
                    s.State = SampleState.在库;
                    sc.SaveChanges();
                    return s;
                }
                else return null;
            }
        }
        /// <summary>
        /// 请求入库
        /// </summary>
        /// <param name="styleId"></param>
        /// <returns></returns>
        public static SampleBaseInfo RequestPutInStorage(string styleId)
        {
            using (SampleContext sc = new SampleContext())
            {
                SampleBaseInfo s = sc.SampleBaseInfos.FirstOrDefault(p => p.StyleId == styleId);
                if (s != null)
                {
                    s.State = SampleState.待入库;
                    sc.SaveChanges();
                    return s;
                }
                else return null;
            }
        }

        public static object GetSampleList(Func<SampleBaseInfo, bool> whereLambda = null, Func<SampleBaseInfo, object> orderbyLamba = null, int PageId = 1, int PageSize = 20)
        {
            if (orderbyLamba == null) orderbyLamba = p => p.State;
            if (whereLambda == null) whereLambda = (p => true);
            using (SampleContext sc = new SampleContext())
            {
                int count = sc.SampleBaseInfos.Count(whereLambda);
                List<SampleBaseInfo> sampleinfo = sc.SampleBaseInfos.Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.Id).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
                List<object> obj = new List<object>();
                sampleinfo.ForEach(p =>
                {
                    obj.Add(SampleHelper.GetReturnObj(p));
                });
                return new { items = obj, total = count, current = PageId, pageSize = PageSize };
            }
        }

        public static object GetSampleListOrderByDesc(Func<SampleBaseInfo, bool> whereLambda = null, Func<SampleBaseInfo, object> orderbyLamba = null, int PageId = 1, int PageSize = 20)
        {
            if (orderbyLamba == null) orderbyLamba = p => p.State;
            if (whereLambda == null) whereLambda = (p => true);
            using (SampleContext sc = new SampleContext())
            {
                int count = sc.SampleBaseInfos.Count(whereLambda);
                List<SampleBaseInfo> sampleinfo = sc.SampleBaseInfos.Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(p => p.Id).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
                List<object> obj = new List<object>();
                sampleinfo.ForEach(p =>
                {
                    obj.Add(SampleHelper.GetReturnObj(p));
                });
                return new { items = obj, total = count, current = PageId, pageSize = PageSize };
            }
        }
    }



}
