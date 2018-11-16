using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleDataOper;
using SG.SessionManage;
using SampleBLL;

namespace SampleApi.Controllers.Sample
{
    [Author]
    public class MySampleController : ApiController
    {
        [HttpPost]
        public object GetLendOutSample(dynamic seachObj)
        {
            var  user = SessionManage.CurrentUser;
            string cstr = (string)seachObj.current; ;
            string cpage = seachObj.pageSize;
            int current = cstr == "" ? 1 : int.Parse(cstr);
            int pageSize = cpage == "" ? 20 : int.Parse(cpage);
            var re = SampleLend.GetLendOutListPC(user);
            return Ok(re);

        }

        [HttpPost]
        public object GetNotInStorageSample(dynamic seachObj)
        {
            string ddid = SessionManage.CurrentUser.DdId;
            string cstr = (string)seachObj.current; ;
            string cpage = seachObj.pageSize;
            int current = cstr == "" ? 1 : int.Parse(cstr);
            int pageSize = cpage == "" ? 20 : int.Parse(cpage);
            var re = SampleOper.GetSampleListOrderByDesc(p => !p.IsDelete && p.DdId == ddid && (int)p.State <=2,t=>t.State, current, pageSize);
            return Ok(re);
        }

        [HttpPost]
        public object GetInStorageSample(dynamic seachObj)
        {
            string ddid = SessionManage.CurrentUser.DdId;
            string cstr = (string)seachObj.current; ;
            string cpage = seachObj.pageSize;
            int current = cstr == "" ? 1 : int.Parse(cstr);
            int pageSize = cpage == "" ? 20 : int.Parse(cpage);
            var re = SampleOper.GetSampleList(p => !p.IsDelete && p.DdId == ddid && (int)p.State >= 3, t => t.State, current, pageSize);
            return Ok(re);
        }
    }
}
