using System.Collections.Generic;
using DingTalk.Api.Response;
using SG.Model.Sys;

namespace SG.DdApi
{
    public interface IDdOper
    {
        string AccessToken { get; }
        string AgentID { get; set; }
        string CorpId { get; set; }
        string CorpSecret { get; set; }
        string JsApiTicket { get; }
        string GetDeptName(long DeptId);
        void SetDept(List<Dept> depts);
    }
}