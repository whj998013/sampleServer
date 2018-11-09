using SG.DdApi;
using SG.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleApi.Controllers
{
    public class DdController : ApiController
    {
        [HttpPost]
        public object GetDdSign(dynamic Url)
        {
            var url = (string)Url.url;
            var ddoper = DdOperator.GetDdApi();
            var agentId = ddoper.AgentID;
            var corpId = ddoper.CorpId;
            var nonceStr = CommonHelper.randNonce();
            var timestamp = DdOperator.TimeStamp();            
            var signature = ddoper.GetSignature(nonceStr, timestamp, url);

            return Ok(new  { agentId,corpId,nonceStr,timestamp,signature,url});
        }

    }
}
