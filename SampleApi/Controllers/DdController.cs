using SG.DdApi;
using SG.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SysBLL;
using System.Web;
using System.Threading.Tasks;
using SG.SessionManage;

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
            var timestamp = ddoper.TimeStamp();
            var signature = ddoper.GetSignature(nonceStr, timestamp, url);
            return Ok(new { agentId, corpId, nonceStr, timestamp, signature, url });
        }
        public IHttpActionResult DdCallBack(dynamic e)
        {
            //接收回调事件
            string encrypt = (string)e.encrypt;
            var request = HttpContext.Current.Request;
            string signature = request["signature"];
            string timestamp = request["timestamp"];
            string nonce = request["nonce"];
            DdEncrypt de = new DdEncrypt(DdOperator.GetDdApi());
            //解密加调事件
            string re = de.DecryptMsg(encrypt, signature, timestamp, nonce);
                     
            //处理回调事件
            Task.Run(() =>
            {
                //事件为审批回调，启用异步处理
                dynamic robj = JsonHelper.ToObj(re);
                new DdCallBackSysOper().DdCallBack(robj);
            });

            //返回加密成功标志给钉钉
            var obj = de.EncryptMsg("success");
            return Ok(obj);
        }

    }
}
