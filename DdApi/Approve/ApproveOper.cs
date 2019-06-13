using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using SG.Model.Sys;
using SG.Utilities;
namespace SG.DdApi.Approve
{
   public class ApproveOper
    {
        private IDdOper _oper;
        public ApproveOper(IDdOper oper)
        {
            _oper = oper;
        }

        public OapiProcessinstanceGetResponse.ProcessInstanceTopVoDomain GetApprove(string processInstanceId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/processinstance/get");
            OapiProcessinstanceGetRequest request = new OapiProcessinstanceGetRequest();
            request.ProcessInstanceId= processInstanceId;
            OapiProcessinstanceGetResponse response = client.Execute(request, _oper.AccessToken);
            if (response.Errcode == 0) return response.ProcessInstance;
            else return null;
        }
    }
}
