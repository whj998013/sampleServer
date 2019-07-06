using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SunginData;
using SG.Model.Sample;
using SG.SessionManage;
using SampleBLL;
using SampleBLL.Model;
using SG.Interface.Sample;

namespace SampleApi.Controllers.Sample
{
    [Author]
    public class InOutStorageController : ApiController
    {
        [HttpPost]
        public object PutInStorage(dynamic obj)
        {
            string id = (string)obj.styleId;
            if (id != "")
            {
                ISampleBaseInfo sample = new SampleBaseInfo();
                string title, content;
                if (Config.GetSampleConfig().IsInputStrageNeedAlow)
                {
                    sample = SampleOper.RequestPutInStorage(id);
                    title = "已发送入库申请";
                    content = "请将样衣交给样衣管理员";
                }
                else
                {
                    sample = SampleOper.PutInStorage(id);
                    title = "入库成功";
                    content = "已入库成功";
                }
                //发钉钉消息
                if (sample != null) return Ok(new { title, content, sample.State, StateText = sample.State.ToString() });
                else return BadRequest("样衣ID不存在");
            }
            else return BadRequest("没有在请求中找到样衣ID");
        }
        [HttpPost]
        public object AcceptInStorageList(List<string> obj)
        {
            List<string> slist = obj;
            if (slist.Count > 0)
            {
                slist.ForEach(p =>
                {
                    SampleOper.AcceptInStorage(p);
                });
            };
           return Ok();
        }

        [HttpPost]
        public object AcceptInStorage(dynamic obj)
        {
            string id = (string)obj.styleId;
            if (id != "")
            {
                var sample = SampleOper.AcceptInStorage(id);
                //发钉钉消息

                if (sample != null) return Ok("ok");
                else return BadRequest("样衣ID不存在");
            }
            else return BadRequest("没有在请求中找到样衣ID");
        }

        [HttpPost]
        public object DeleteSample(dynamic obj)
        {
            string id = (string)obj.styleId;
            if (id != "")
            {
                var sample = SampleOper.DeleteSample(id, SessionManage.CurrentUser.UserName);
                //发钉钉消息

                if (sample != null) return Ok("ok");
                else return BadRequest("样衣ID不存在");
            }
            return BadRequest("没有在请求中找到样衣ID");
        }
        /// <summary>
        /// 返回待入库清单
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public object GetInStorageList(SeachModel obj)
        {
            object re ;
            if (obj.UserId.Count > 0)
            {
                var exp = PredicateBuilder.False<ISampleBaseInfo>();
                var exp2 = PredicateBuilder.True<ISampleBaseInfo>();
                obj.UserId.ForEach(p =>
                {
                    exp = exp.Or(t => t.DdId==p);
                });
                exp2 = exp2.And(p => !p.IsDelete && p.State == SampleState.待入库).And(exp);
             
                 re=SampleOper.GetSampleListOrderByDesc(exp2.Compile(), p => p.CreateDate, obj.Current, obj.PageSize);
            }
            else
            {
                re=SampleOper.GetSampleListOrderByDesc(p => !p.IsDelete && p.State == SampleState.待入库, p => p.CreateDate, obj.Current, obj.PageSize);
            }

            return Ok(re);
        }
        /// <summary>
        /// 取得有待入库样品的用户清单,返回ddid和name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetInStorageUserList()
        {

            return Ok(UserOper.GetInStorageUserList());
        }
    }
}
