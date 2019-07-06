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
            var re = SampleLend.GetLendOutListDD(user);
            if (re == null) return NotFound();
            return Ok(re);
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
                       re = SampleLend.DoDelete(p, user);
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
        public IHttpActionResult ApplyLendOut(List<int> LendIdList)
        {
            User user = SessionManage.CurrentUser;

            if (LendIdList.Count > 0)
            {
                LendIdList.ForEach(p =>
                {
                    bool re = SampleLend.ApplyLendOut(p, user);

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
        /// 返回有借用样衣的用户清单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetLendoutUserList()
        {
            var re = SampleLend.GetLendOutUserList();
            return Ok(re);
        }
        /// <summary>
        /// 返回借用申请的用户清单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetLendUserList()
        {
            var re = SampleLend.GetLendUserList();
            return Ok(re);
        }
        /// <summary>
        /// 返回待借用清单
        /// </summary>
        /// <param name="seachObj"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetAllLendList(SeachModel seachObj)
        {
            var re = SampleLend.GetAllLendList(seachObj.Current, seachObj.PageSize);
            return Ok(re);
        }
        [HttpPost]
        public object GetAllLendOutList(SeachModel seachObj)
        {
            var re = SampleLend.GetAllLendOutList(seachObj.Current, seachObj.PageSize);
            return Ok(re);
        }
        /// <summary>
        /// 执行通过借用申请 
        /// </summary>
        /// <param name="styleIdList"></param>
        /// <returns></returns>

        [HttpPost]
        public object DoInstroage(List<int> LendIdList)
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
        public object DoBackLend(List<int> lendId)
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
        public object DoReturnLend(List<int> LendIdList)
        {
            User user = SessionManage.CurrentUser;
            LendIdList.ForEach(p =>
            {
                SampleLend.DoReturnLend(p, user.UserName);
            });
            return Ok();
        }
    }
}