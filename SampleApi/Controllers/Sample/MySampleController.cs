using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SunginData;
using SG.SessionManage;
using SampleBLL;

namespace SampleApi.Controllers.Sample
{
    [Author]
    public class MySampleController : ApiController
    {
        [HttpPost]
        public object GetLendOutSample(SeachObjSample seachObj)
        {
            var  user = SessionManage.CurrentUser;
            var re = SampleLend.GetLendOutListPC(user);
            return Ok(re);

        }

        [HttpPost]
        public object GetNotInStorageSample(SeachObjSample seachObj)
        {
            string ddid = SessionManage.CurrentUser.DdId;
            var re = SampleOper.GetSampleListOrderByDesc(p => !p.IsDelete && p.DdId == ddid && (int)p.State <=2,t=>t.CreateDate, seachObj.PageId, seachObj.PageSize);
            return Ok(re);
        }

        [HttpPost]
        public object GetInStorageSample(SeachObjSample seachObj)
        {
            string ddid = SessionManage.CurrentUser.DdId;
            var re = SampleOper.GetSampleList(p => !p.IsDelete && p.DdId == ddid && (int)p.State >= 3, t => t.CreateDate, seachObj.PageId, seachObj.PageSize);
            return Ok(re);
        }
    }
}
