using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Utilities;
using SunginData;
using SG.Model.Sys;
using SG.Model.Sample;
using SG.Interface.Sample;
using SG.Interface;
namespace SampleBLL
{
    public class SampleLend
    {
        /// <summary>
        /// 样衣借出
        /// </summary>
        /// <param name="styleId"></param>
        /// <param name="_user"></param>
        /// <returns></returns>
        public static bool DoLend(string styleId, User _user)
        {
            using SunginDataContext sc = new SunginDataContext();
            var style = sc.SampleBaseInfos.SingleOrDefault(p => p.StyleId == styleId);
            LendRecord lr = sc.LendRecords.SingleOrDefault(p => p.StyleId == styleId && p.DdId == _user.DdId && (p.State != LendRecordStats.已还回));
            if (style != null && lr == null)
            {

                lr = new LendRecord
                {
                    StyleId = style.StyleId,
                    DdId = _user.DdId,
                    UserName = _user.UserName,
                    UserDept = _user.DepartName,
                };
                lr.SetCreateUser(_user.UserName);
                sc.LendRecords.Add(lr);
            }
            else return false;
            sc.SaveChanges();
            return true;

        }


        public static object GetLendOutListPC(User _user)
        {
            using SunginDataContext sc = new SunginDataContext();
            var lendlist = sc.LendRecords.Where(p => p.DdId == _user.DdId && (p.State == LendRecordStats.借出审批 || p.State == LendRecordStats.已借出)).ToList();
            List<object> lo = new List<object>();
            lendlist.ForEach(p =>
            {
                var sb = sc.SampleBaseInfos.SingleOrDefault(t => t.StyleId == p.StyleId);
                if (sb != null) lo.Add(SampleHelper.GetReturnObj(sb));
            });

            if (lo.Count == 0) lo = null;
            return new { items = lo };

        }

        /// <summary>
        /// 当前用户的借出清单
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static object GetLendOutListDD(User _user)
        {
            using SunginDataContext sc = new SunginDataContext();
            var lendlist = sc.LendRecords.Where(p => p.DdId == _user.DdId && (p.State == LendRecordStats.借出审批 || p.State == LendRecordStats.已借出)).ToList();
            List<object> lo = new List<object>();
            lendlist.ForEach(p =>
            {
                var obj = SampleHelper.GetDdLenOutObj(p);
                if (obj != null) lo.Add(obj);

            });

            if (lo.Count == 0) lo = null;
            return lo;
        }



        /// <summary>
        /// 取消借用审批中的样衣借用
        /// </summary>
        /// <param name="StyleId"></param>
        /// <param name="user">借用者</param>
        /// <returns></returns>
        public static bool CancelLend(string StyleId, User _user)
        {
            using SunginDataContext sc = new SunginDataContext();
            var lr = sc.LendRecords.SingleOrDefault(p => p.StyleId == StyleId && p.DdId == _user.DdId && p.State == LendRecordStats.借出审批);
            if (lr != null)
            {
                sc.Entry(lr).State = System.Data.Entity.EntityState.Deleted;
                sc.SampleBaseInfos.SingleOrDefault(p => p.StyleId == StyleId).State = SampleState.在库;
                sc.SaveChanges();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// 取得有样及入库的用户清单
        /// </summary>
        /// <returns></returns>
        public static object GetInUserList()
        {
            using SunginDataContext sc = new SunginDataContext();
            var re = sc.LendOutViews.Select(p => new { DdId = p.InDdId, Name = p.InUserName }).Distinct().ToList();
            return re;
        }



        /// <summary>
        /// 执行退回申请
        /// </summary>
        /// <param name="styleId"></param>
        /// <param name="user"></param>
        public static bool DoBackLend(int LenId, string user)
        {
            using SunginDataContext sc = new SunginDataContext();
            var sl = sc.LendRecords.SingleOrDefault(p => !p.IsDelete && p.Id == LenId);
            if (sl != null)
            {
                sl.State = LendRecordStats.草拟;
                sl.OperRemark = sl.OperRemark + " 退回借出申请：" + user;
                var sb = sc.SampleBaseInfos.SingleOrDefault(p => !p.IsDelete && p.StyleId == sl.StyleId);
                if (sb != null)
                {
                    sb.State = SampleState.在库;
                }
                else
                {
                    sl.Delete(user);
                }
                sc.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 执行还回操作
        /// </summary>
        /// <param name="p"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool DoReturnLend(int LendId, string user)
        {

            using SunginDataContext sc = new SunginDataContext();
            var sl = sc.LendRecords.SingleOrDefault(p => !p.IsDelete && p.Id == LendId);
            if (sl != null)
            {
                sl.State = LendRecordStats.已还回;
                sl.ReturnDate = DateTime.Now;
                sl.OperRemark = sl.OperRemark + " 还回审批人：" + user;
                var sb = sc.SampleBaseInfos.SingleOrDefault(p => !p.IsDelete && p.StyleId == sl.StyleId);
                sb.State = SampleState.在库;
                sc.SaveChanges();
                return true;
            }
            else return false;

        }

        /// <summary>
        /// 执行通过借出申请
        /// </summary>
        /// <param name="styleId"></param>
        public static bool DoInstroage(int LendId, string user)
        {
            using SunginDataContext sc = new SunginDataContext();
            var sl = sc.LendRecords.SingleOrDefault(p => !p.IsDelete && p.Id == LendId);
            if (sl != null)
            {
                sl.State = LendRecordStats.已借出;
                sl.LendOutDate = DateTime.Now;
                sl.OperRemark = sl.OperRemark + " 借出审批人：" + user;
                var sb = sc.SampleBaseInfos.SingleOrDefault(p => !p.IsDelete && p.StyleId == sl.StyleId);
                sb.State = SampleState.借出;
                sc.SaveChanges();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 执行借出申请
        /// </summary>
        /// <param name="_lendOutNo"></param>
        /// <returns></returns>
        public static bool ApplyLendOut(int LendId, int LendDay, string LendPurpost)
        {
            using SunginDataContext sc = new SunginDataContext();
            var lr = sc.LendRecords.SingleOrDefault(p => p.Id == LendId);
            SampleBaseInfo sb = sc.SampleBaseInfos.SingleOrDefault(s => s.StyleId == lr.StyleId);
            // if (sb != null && sb.State == SampleState.在库)
            if (sb != null)
            {
                lr.State = LendRecordStats.借出审批;
                lr.LendDay = LendDay;
                lr.LendPurpose = LendPurpost;
                sb.State = SampleState.待借出;
                lr.LendOutNo = "";
                sc.Entry(lr).State = System.Data.Entity.EntityState.Modified;
                sc.Entry(sb).State = System.Data.Entity.EntityState.Modified;
                //ishavelend = true;
            }
            //else sc.Entry(lr).State = System.Data.Entity.EntityState.Deleted;  //不在库中从借出审批中删除
            sc.SaveChanges();
            return true;

        }

        /// <summary>
        /// 删除指定待借样衣
        /// </summary>
        /// <param name="styleId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool DoDelete(int LendId)
        {
            using SunginDataContext sc = new SunginDataContext();
            LendRecord lr = sc.LendRecords.SingleOrDefault(p => p.Id == LendId);
            if (lr != null) sc.Entry(lr).State = System.Data.Entity.EntityState.Deleted;
            else return false;
            sc.SaveChanges();
            return true;

        }

        public static object GetLendChart(out int Count, Func<LendOutView, bool> whereLambda, int PageId, int PageSize)
        {
            using SunginDataContext sc = new SunginDataContext();
            Count = sc.LendOutViews.Where(whereLambda).GroupBy(p => p.StyleId).Count();
            var list = sc.LendOutViews.Where(whereLambda).GroupBy(p => new { p.StyleId, p.StyleNo, p.StylePic, p.InUserName, p.Kinds }).Select(p => new { p.Key.StyleId, p.Key.Kinds, p.Key.StyleNo, p.Key.StylePic, p.Key.InUserName, LendCount = p.Count() }).OrderByDescending(p => p.LendCount).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList(); ;

            return list;
        }

        /// <summary>
        /// 返回当前用户的待借出清单
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public static object GetLendList(User _user)
        {
            using SunginDataContext sc = new SunginDataContext();
            //SampleLendout slo = sc.SampleLendouts.SingleOrDefault(p => p.DdId == _user.DdId && p.State == LendStats.草拟);
            var lendlist = sc.LendRecords.Where(p => p.DdId == _user.DdId && p.State == LendRecordStats.草拟).ToList();
            List<object> lo = new List<object>();
            lendlist.ForEach(p =>
            {
                var obj = SampleHelper.GetDdLenOutObj(p);
                if (obj != null) lo.Add(obj);
            });

            return lo;
        }

        /// <summary>
        /// 返回有借用申请的用户清单
        /// </summary>
        /// <returns></returns>
        public static object GetLendUserList(LendRecordStats stats)
        {
            using SunginDataContext sc = new SunginDataContext();
            var re = sc.LendRecords.Where(p => p.State == stats).Select(p => new { p.DdId, Name = p.UserName }).Distinct().ToList();
            return re;
        }
        /// <summary>
        /// 返回所有借出申请单
        /// </summary>
        /// <returns></returns>
        public static object GetAllLendList(int PageId = 1, int PageSize = 20)
        {

            using SunginDataContext sc = new SunginDataContext();
            int count = sc.LendRecords.Count(p => !p.IsDelete && p.State == LendRecordStats.借出审批);

            List<LendRecord> lr = sc.LendRecords.Where(p => !p.IsDelete && p.State == LendRecordStats.借出审批).OrderByDescending(p => p.DdId).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            List<object> obj = new List<object>(); ;
            lr.ForEach(p =>
            {
                var sb = sc.SampleBaseInfos.SingleOrDefault(t => t.StyleId == p.StyleId);
                obj.Add(new { p.Id, p.StyleId, p.UserName, p.UserDept, sb.StyleNo, p.CreateDate, baseinfo = SampleHelper.GetReturnObj(sb) });
            });
            return new { items = obj, total = count, current = PageId, pageSize = PageSize };
        }
        /// <summary>
        /// 返回所有借用清单
        /// </summary>
        /// <param name="PageId"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static object GetAllLendOutList(int PageId = 1, int PageSize = 20)
        {
            using SunginDataContext sc = new SunginDataContext();
            int count = sc.LendRecords.Count(p => !p.IsDelete && p.State == LendRecordStats.已借出);

            List<LendRecord> lr = sc.LendRecords.Where(p => !p.IsDelete && p.State == LendRecordStats.已借出).OrderByDescending(p => p.DdId).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            List<object> obj = new List<object>(); ;
            lr.ForEach(p =>
            {
                var sb = sc.SampleBaseInfos.SingleOrDefault(t => t.StyleId == p.StyleId);
                obj.Add(new { p.Id, p.StyleId, p.UserName, p.UserDept, sb.StyleNo, p.CreateDate, baseinfo = SampleHelper.GetReturnObj(sb) });
            });
            return new { items = obj, total = count, current = PageId, pageSize = PageSize };
        }

        /// <summary>
        /// 返回所有借用还回清单
        /// </summary>
        /// <param name="PageId"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static object GetLendOutViewList(out int Count, Func<LendOutView, bool> whereLambda, Func<LendOutView, object> orderbyLamba, int PageId, int PageSize)
        {
            using SunginDataContext sc = new SunginDataContext();
            Count = sc.LendOutViews.Where(whereLambda).Count();
            var list = sc.LendOutViews.Where(whereLambda).OrderBy(orderbyLamba).ThenByDescending(t => t.Id).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }

        /// <summary>
        /// 返回所有借用还回清单
        /// </summary>
        /// <param name="PageId"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static object GetLendOutViewListByDesc(out int Count, Func<LendOutView, bool> whereLambda, Func<LendOutView, object> orderbyLamba, int PageId, int PageSize)
        {
            using SunginDataContext sc = new SunginDataContext();
            // Count = sc.LendOutViews.Where(whereLambda).Count();
            Count = sc.LendOutViews.AsNoTracking().Count(whereLambda);
            var list = sc.LendOutViews.AsNoTracking().Where(whereLambda).OrderByDescending(orderbyLamba).ThenByDescending(t => t.Id).Skip(PageSize * (PageId - 1)).Take(PageSize).ToList();
            return list;
        }

    }
}

