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
    public class NewApprove
    {
        private IDdOper _oper;

        /// <summary>
        /// 审批流唯一码
        /// </summary>
        public string ProcessCode { get; set; }

        public User User { get; set; }


        public NewApprove(IDdOper oper)
        {
            _oper = oper;
        }
        /// <summary>
        /// 发送审批请求
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public string SendApprove(List<ApproveItem> items)
        {
            DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/processinstance/create");
            OapiProcessinstanceCreateRequest request = new OapiProcessinstanceCreateRequest();
            request.AgentId = long.Parse(_oper.AgentID);
            request.ProcessCode = ProcessCode;

            List<OapiProcessinstanceCreateRequest.FormComponentValueVoDomain> formComponentValues = new List<OapiProcessinstanceCreateRequest.FormComponentValueVoDomain>();
            items.ForEach(p =>
            {
                OapiProcessinstanceCreateRequest.FormComponentValueVoDomain vo = new OapiProcessinstanceCreateRequest.FormComponentValueVoDomain();
                vo.Name = p.Name;
                vo.Value = p.Value;
                vo.ExtValue = p.ExtValue;
                formComponentValues.Add(vo);
            });

            request.FormComponentValues_ = formComponentValues;
            request.OriginatorUserId = User.DdId;
            request.DeptId = JsonHelper.JsonToList<long>(User.DeptId).First();

            OapiProcessinstanceCreateResponse response = client.Execute(request, _oper.AccessToken);
            if (response.Errcode == 0) return response.ProcessInstanceId;
            return "";

        }


    }
}
