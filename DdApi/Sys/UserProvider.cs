using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using SG.Interface.Sys;
using SG.Model.Sys;
namespace SG.DdApi.Sys
{
    public class UserProvider
    {
        private IDdOper DdOper { get; set; }
        public UserProvider(IDdOper ddoper)
        {
            DdOper = ddoper;
        }
        public User GetUserInfo(string DdId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/get");
            OapiUserGetRequest request = new OapiUserGetRequest();
            request.Userid = DdId;
            request.SetHttpMethod("GET");
            OapiUserGetResponse response = client.Execute(request, DdOper.AccessToken);

            if (!response.IsError)
            {
                User u= new User
                {
                    UserName = response.Name,
                    DdId = response.Userid,
                    DepartName = DdOper.GetDeptName(response.Department[0]),
                    Avatar = response.Avatar,
                };
                response.Department.ForEach(p =>
                {
                    if (u.DeptId == "") {
                        u.DeptId = p.ToString();
                        u.DepartName = DdOper.GetDeptName(p);
                    }
                    else
                    {
                        u.DeptId += ","+p.ToString();
                        u.DepartName += "," + DdOper.GetDeptName(p);
                    };

                });
                return u;
            }
            return null;
        }

        /// <summary>
        ///根据免登Code,返回用户业务模型
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetDdIdByCode(string code)
        {
            OapiUserGetuserinfoResponse idmd = GetCurrentUserIdModel(DdOper.AccessToken, code);
            if (idmd.Errcode != 0) return null;
            return idmd.Userid;
        }
        
        /// <summary>
        /// 取得当前用户ID,返回订订模型
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private OapiUserGetuserinfoResponse GetCurrentUserIdModel(string access_token, string code)
        {
          

            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/getuserinfo");
            OapiUserGetuserinfoRequest request = new OapiUserGetuserinfoRequest();
            request.Code = code;
            request.SetHttpMethod("GET");
            OapiUserGetuserinfoResponse response = client.Execute(request, DdOper.AccessToken);
            return response;

        }
              

    }
}
