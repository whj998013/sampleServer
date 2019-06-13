using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Newtonsoft.Json;
using System.Security.Cryptography;
using DingTalk.Api;
using DingTalk;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using static DingTalk.Api.Response.CorpRoleGetrolegroupResponse;
using static DingTalk.Api.Response.OapiUserListResponse;
using SG.Model.Sys;
using SG.Utilities.Base.Security;
namespace SG.DdApi
{
    public class DdOperator : IDdOper
    {
        private static DdOperator _instance = null; //单列对象
        private string accessToken, jsApiTicket;
        private DateTime accessTokenTime = DateTime.Parse("1900-01-01");
        private List<Dept> _deptList { get; set; } = new List<Dept>();
        /// <summary>
        /// 设置应用ID
        /// </summary>
        public string AgentID { get; set; }
        /// <summary>
        /// 设置企业ID
        /// </summary>
        public string CorpId { get; set; }
        /// <summary>
        /// 设置企业密钥
        /// </summary>
        public string CorpSecret { get; set; }
        public List<Dept> DeptList { get { return _deptList; } }
        private DdOperator()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, error) =>
            {
                return true;
            };

        }

        ///取得单例类实例
        public static DdOperator GetDdApi()
        {
            if (_instance == null)
            {
                _instance = new DdOperator();
            }
            return _instance;
        } 
    
        /// <summary>
        /// 返回AccessToken
        /// </summary>
        public string AccessToken
        {
            get
            {
                TimeSpan ts = DateTime.Now - accessTokenTime;
                if (ts.TotalSeconds < 7000 & accessToken != "")
                {
                    return accessToken; //在有效期内，直接返回
                }
                else
                {
                    GetAccessTokenAndJsTicket();  //重新生成并返回
                    return accessToken;
                }
            }
        }



        /// <summary>
        /// 返回钉钉免登签名
        /// </summary>
        /// <param name="nonceStr"></param>
        /// <param name="timeStamp"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetSignature(string nonceStr, string timeStamp, string url)
        {
            string str1 = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", JsApiTicket, nonceStr, timeStamp, url);
            string signature = SH1Helper.GetSwcSH1(str1).ToLower();
            // string signature = FormsAuthentication.HashPasswordForStoringInConfigFile(str1, "SHA1").ToLower();
            return signature;
        }

        /// <summary>
        /// 返回jsapiticket
        /// </summary>
        public string JsApiTicket
        {
            get
            {
                TimeSpan ts = DateTime.Now - accessTokenTime;
                if (ts.TotalSeconds < 6000)
                {
                    return jsApiTicket; //在有效期内，直接返回
                }
                else
                {
                    GetAccessTokenAndJsTicket();  //重新生成并返回
                    return jsApiTicket;
                }
            }
        }

        /// <summary>
        /// 根据部门ID取得部部门名字
        /// </summary>
        /// <param name="DeptId"></param>
        /// <returns></returns>
        public string GetDeptName(long DeptId)
        {
            var re = _deptList.SingleOrDefault(p => p.DeptID == DeptId);
            if (re != null) return re.DeptName;
            return "";
        }
            
        /// <summary>
        /// 生成accessToken
        /// </summary>
        private void GetAccessTokenAndJsTicket()
        {
            accessToken = GetAccessToken(CorpId, CorpSecret);
            jsApiTicket = GetJsApiTicket(accessToken);
            accessTokenTime = DateTime.Now;

        }

        /// <summary>
        /// 生成JsAipTicket
        /// </summary>
        /// <param name="_accessToken"></param>
        /// <returns></returns>
        private string GetJsApiTicket(string _accessToken)
        {
            string re = DdHttpHelper.Get(string.Format("https://oapi.dingtalk.com/get_jsapi_ticket?access_token={0}", _accessToken));
            string result = "";
            var obj = JsonConvert.DeserializeObject<Jsticket>(re);
            if (obj.Errcode == 0)
            {
                result = obj.Ticket;
            }

            return result;
        }

        public void SetDept(List<Dept> depts)
        {
            _deptList.Clear();

            depts.ForEach(p =>_deptList.Add(p));
        }

      

        /// <summary>
        /// 根据企业尖,和密码返回 AccessToken
        /// </summary>
        /// <param name="CorpId"></param>
        /// <param name="CorpSecret"></param>
        /// <returns></returns>
        private string GetAccessToken(string CorpId, string CorpSecret)
        {
         
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
            OapiGettokenRequest request = new OapiGettokenRequest();
            request.Appkey= CorpId;
            request.Appsecret= CorpSecret;
            request.SetHttpMethod("GET");
            OapiGettokenResponse response = client.Execute(request);
            return response.AccessToken;
        }

        /// <summary>
        /// 生成时间戳
        /// </summary>
        /// <returns></returns>
        public  string TimeStamp()
        {
            DateTime dt1 = Convert.ToDateTime("1970-01-01 00:00:00");
            TimeSpan ts = DateTime.Now - dt1;
            return Math.Ceiling(ts.TotalSeconds).ToString();
        }
             
    

    }

}
