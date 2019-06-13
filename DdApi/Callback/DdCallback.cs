using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DdApi
{
    /// <summary>
    /// 事件回调接口操作
    /// </summary>
    public class DdCallbackOper
    {
        IDdOper _ddoper;
        public string CallBackUrl { get; set; } = "http://api.sungingroup.com:8082/api/dd/DdCallBack";
        public string AesKey { get; set; } = "99801378901234567890nicky67890123wyy7890whj";
        public string Token { get; set; } = "880212";
        public List<string> Ls { get; set; } = new List<string>() { "bpms_instance_change" };
        public DdCallbackOper(IDdOper ddOper)
        {
            _ddoper = ddOper;
        }
        // public string Url { get; set; }

        public void RegisterCallBack()
        {
            var reg = GetRegister();
            if (reg.Errcode == 0)
            {
                if (reg.AesKey != AesKey || reg.Url != CallBackUrl || reg.Token != Token || !Enumerable.SequenceEqual(Ls, reg.CallBackTag)) UpdataRegister();

            }
            else
            {
                SendRegister();
            }

        }

        public OapiCallBackGetCallBackFailedResultResponse GetFailCallBack()
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/call_back/get_call_back_failed_result");
            OapiCallBackGetCallBackFailedResultRequest request = new OapiCallBackGetCallBackFailedResultRequest();
            request.SetHttpMethod("GET");
            OapiCallBackGetCallBackFailedResultResponse response = client.Execute(request, _ddoper.AccessToken);
            return response;
        }
        public OapiCallBackRegisterCallBackResponse SendRegister()
        {
            //注册钉钉回调接口
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/call_back/register_call_back");
            OapiCallBackRegisterCallBackRequest request = new OapiCallBackRegisterCallBackRequest
            {
                Url = CallBackUrl,
                AesKey = AesKey,
                Token = Token,
                CallBackTag = Ls
            };
            OapiCallBackRegisterCallBackResponse response = client.Execute(request, _ddoper.AccessToken);
            return response;
        }

        public OapiCallBackGetCallBackResponse GetRegister()
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/call_back/get_call_back");
            OapiCallBackGetCallBackRequest request = new OapiCallBackGetCallBackRequest();
            request.SetHttpMethod("GET");
            OapiCallBackGetCallBackResponse response = client.Execute(request, _ddoper.AccessToken);
            return response;
        }

        public OapiCallBackUpdateCallBackResponse UpdataRegister()
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/call_back/update_call_back");
            OapiCallBackUpdateCallBackRequest request = new OapiCallBackUpdateCallBackRequest
            {
                Url = CallBackUrl,
                AesKey = AesKey,
                Token = Token,
                CallBackTag = Ls
            };
            OapiCallBackUpdateCallBackResponse response = client.Execute(request, _ddoper.AccessToken);
            return response;
        }

        public bool DeleteRegister()
        {
            DefaultDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/call_back/delete_call_back");
            OapiCallBackDeleteCallBackRequest request = new OapiCallBackDeleteCallBackRequest();
            request.SetHttpMethod("GET");
            OapiCallBackDeleteCallBackResponse response = client.Execute(request, _ddoper.AccessToken);
            if (response.Errcode == 0) return true;
            return false;
        }
    }
}
