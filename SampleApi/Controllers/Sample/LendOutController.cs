using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG.SessionManage;
using SunginData;
using SampleApi.Controllers.Sample;
using SampleBLL;
using SampleBLL.Model;
using SG.Model.Sys;
using SG.Utilities;
using SG.Model.Sample;
using SG.Interface.Sample;

namespace SampleApi.Controllers
{
    [Author]
    public class LendOutController : ApiController
    {
        /// <summary>
        /// 将样衣放入待借出记录中,obj={StyleId:"SI10002001"}
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DoLendOut(dynamic obj)
        {
            string styleId = (string)obj.styleId;
            User user = SessionManage.CurrentUser;
            if (styleId != "")
            {
                bool re = SampleLend.DoLend(styleId, user);
                if (re) return Ok();
                else return BadRequest("样衣已在借用清单中");
            }
            else return NotFound();
        }
        /// <summary>
        /// 当前用户的已借出样衣清单
        /// </summary>
        /// <returns></returns>

        public IHttpActionResult GetLendOutList()
        { 
            User user = SessionManage.CurrentUser;
            var exp = PredicateBuilder.True<LendOutView>().And(t => !t.IsDelete &&(t.State == LendRecordStats.借出审批||t.State==LendRecordStats.已借出)&&t.DdId==user.DdId);
            var list = SampleLend.GetLendOutViewListByDesc(out int count, exp.Compile(), p => p.CreateDate,1, 6000);

            //var re = SampleLend.GetLendOutListDD(user);
            //if (re == null) return NotFound();
            return Ok(new { count,list});
        }
        /// <summary>
        /// 客户端取得当前用户的待借出清单
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetLendList()
        {
            User user = SessionManage.CurrentUser;
            var re = SampleLend.GetLendList(user);
            if (re != null) return Ok(re);
            else return NotFound();
        }
        /// <summary>
        /// 从待借库中删除指定style 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DeleteLend(List<int> LendIdList)
        {
            bool re = false;
            User user = SessionManage.CurrentUser;
            if (LendIdList.Count > 0)
            {
                LendIdList.ForEach(p =>
                   {
                       re = SampleLend.DoDelete(p);
                   });

                if (re) return Ok();
                else return BadRequest("样衣已删除或不存在");
            }
            else return NotFound();
        }
        /// <summary>
        /// 发出借出申请
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ApplyLendOut(dynamic requestObj)
        {
            User user = SessionManage.CurrentUser;
            int LendDay = requestObj.lendDay;
            string LendPurpost = requestObj.lendPurpost;
            List<int> LendIdList = requestObj.lendIdList.ToObject<List<int>>();

            if (LendIdList.Count > 0)
            {
                LendIdList.ForEach(p =>
                {
                    bool re = SampleLend.ApplyLendOut(p, LendDay, LendPurpost);

                });
                return Ok();
            }
            else return NotFound();

        }
        /// <summary>
        /// 取消借用审批中的样衣借用
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CancelLend(dynamic obj)
        {

            User user = SessionManage.CurrentUser;
            string StyleId = (string)obj.StyleId;
            if (StyleId != "")
            {
                if (SampleLend.CancelLend(StyleId, user)) return Ok();
                else return NotFound();


            }
            else return BadRequest("请传入样衣有效ID");
        }
        /// <summary>
        /// 返回借用申请的用户清单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetLendUserList(int id)
        {

            var re = SampleLend.GetLendUserList((SG.Interface.Sample.LendRecordStats)id);
            return Ok(re);
        }

        /// <summary>
        /// 返回有样衣入库用户清单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetInUserList()
        {

            var re = SampleLend.GetInUserList();
            return Ok(re);
        }
        /// <summary>
        /// 返回待借用清单
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetAllLendList(SeachObjSample obj)
        {
            if (obj == null) return BadRequest();
            var exp = PredicateBuilder.True<LendOutView>().And(t => !t.IsDelete && t.State == LendRecordStats.借出审批);
            if (obj.UserId.Count > 0)
            {
                exp = exp.And(t => obj.UserId.Contains(t.DdId));
            }
            if (obj.InUserId!=null&&obj.InUserId.Count > 0)
            {
                exp = exp.And(t => obj.InUserId.Contains(t.InDdId));
            }
             var list = SampleLend.GetLendOutViewListByDesc(out int count, exp.Compile(), p => p.CreateDate, obj.PageId, obj.PageSize);

            //var re = SampleLend.GetAllLendList(obj.PageId, obj.PageSize);
            return Ok(new { count, list });
        }
        /// <summary>
        /// 返回已还回的借用清单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetAllLendOutReturnList(SeachObjSample obj)
        {
            if (obj == null) return BadRequest();
            var exp = PredicateBuilder.True<LendOutView>().And(t => !t.IsDelete && t.State == LendRecordStats.已还回);
            if (obj.UserId.Count > 0)
            {
                exp = exp.And(t => obj.UserId.Contains(t.DdId));
            }
            if (obj.InUserId.Count > 0)
            {
                exp = exp.And(t => obj.InUserId.Contains(t.InDdId));
            }
            if (obj.BeginDate != null && obj.EndDate != null)
            {
                var bd = (DateTime)obj.BeginDate;
                var ed = (DateTime)obj.EndDate;
                exp = exp.And(t => t.LendOutDate >= bd && t.LendOutDate < ed);
            }
            var list = SampleLend.GetLendOutViewListByDesc(out int count, exp.Compile(), p => p.ReturnDate, obj.PageId, obj.PageSize);
            return Ok(new { count, list });
        }

        /// <summary>
        /// 返回已借出的样衣清单
        /// </summary>
        /// <param name="seachObj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetAllLendOutList(SeachObjSample obj)
        {
            if (obj == null) return BadRequest();
            var exp = PredicateBuilder.True<LendOutView>().And(t => !t.IsDelete && t.State == LendRecordStats.已借出);
            if (obj.UserId.Count > 0)
            {
                exp = exp.And(t => obj.UserId.Contains(t.DdId));
            }
            if (obj.InUserId.Count > 0)
            {
                exp = exp.And(t => obj.InUserId.Contains(t.InDdId));
            }


            var list = SampleLend.GetLendOutViewList(out int count, exp.Compile(), p => p.LendOutDate, obj.PageId, obj.PageSize);
            return Ok(new { count, list });
        }
        /// <summary>
        /// 执行通过借用申请 
        /// </summary>
        /// <param name="styleIdList"></param>
        /// <returns></returns>

        [HttpPost]
        public IHttpActionResult DoInstroage(List<int> LendIdList)
        {
            User user = SessionManage.CurrentUser;
            LendIdList.ForEach(p =>
            {
                SampleLend.DoInstroage(p, user.UserName);
            });
            return Ok();
        }
        /// <summary>
        /// 执行退回申请
        /// </summary>
        /// <param name="styleIdList"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DoBackLend(List<int> lendId)
        {
            User user = SessionManage.CurrentUser;
            lendId.ForEach(p =>
            {
                SampleLend.DoBackLend(p, user.UserName);
            });
            return Ok();
        }

        /// <summary>
        /// 执行已借样衣还回申请
        /// </summary>
        /// <param name="styleIdList"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DoReturnLend(List<int> LendIdList)
        {
            User user = SessionManage.CurrentUser;
            LendIdList.ForEach(p =>
            {
                SampleLend.DoReturnLend(p, user.UserName);
            });
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult GetLendChart(SeachObjSample obj)
        {
            if (obj == null) return BadRequest();
            var exp = PredicateBuilder.True<LendOutView>().And(t => !t.IsDelete && t.State == LendRecordStats.已还回);
            if (obj.InUserId.Count > 0)
            {
                exp = exp.And(t => obj.InUserId.Contains(t.InDdId));
            }
            if (obj.BeginDate != null && obj.EndDate != null)
            {
                exp = exp.And(t => t.ReturnDate >= obj.BeginDate && t.ReturnDate <= ((DateTime)obj.EndDate).AddDays(1));
            }
            var list = SampleLend.GetLendChart(out int count, exp.Compile(), obj.PageId, obj.PageSize);
            return Ok(new { count, list });
        }
    }
}