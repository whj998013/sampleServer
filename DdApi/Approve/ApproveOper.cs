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
using static DingTalk.Api.Request.OapiProcessWorkrecordTaskgroupCancelRequest;

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
            request.ProcessInstanceId = processInstanceId;
            OapiProcessinstanceGetResponse response = client.Execute(request, _oper.AccessToken);
            if (response.Errcode == 0) return response.ProcessInstance;
            else return null;
        }

        //public bool CancelApprove(string processId)
        //{
        //    IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/process/workrecord/taskgroup/cancel");
        //    OapiProcessWorkrecordTaskgroupCancelRequest req = new OapiProcessWorkrecordTaskgroupCancelRequest();
        //    UpdateTaskRequestDomain obj1 = new UpdateTaskRequestDomain();
        //    obj1.Agentid = long.Parse(_oper.AgentID);
        //    obj1.ProcessInstanceId = processId;
        //    obj1.ActivityId = "aaaa";
        //    req.Request_ = obj1;
        //    OapiProcessWorkrecordTaskgroupCancelResponse rsp = client.Execute(req, _oper.AccessToken);
        //    return true;
        //}
    }
}
