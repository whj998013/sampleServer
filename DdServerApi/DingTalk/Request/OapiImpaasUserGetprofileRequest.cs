using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.impaas.user.getprofile
    /// </summary>
    public class OapiImpaasUserGetprofileRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiImpaasUserGetprofileResponse>
    {
        /// <summary>
        /// 获取profile入参
        /// </summary>
        public string Request { get; set; }

        public GetProfileReqDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.impaas.user.getprofile";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("request", this.Request);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("request", this.Request);
        }

	/// <summary>
/// AccountInfoDomain Data Structure.
/// </summary>
[Serializable]

public class AccountInfoDomain : TopObject
{
	        /// <summary>
	        /// 类型为channelUser有效
	        /// </summary>
	        [XmlElement("channel")]
	        public string Channel { get; set; }
	
	        /// <summary>
	        /// 用户类型对应id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 用户类型 员工:staff 二方：channelUser
	        /// </summary>
	        [XmlElement("type")]
	        public string Type { get; set; }
}

	/// <summary>
/// GetProfileReqDomain Data Structure.
/// </summary>
[Serializable]

public class GetProfileReqDomain : TopObject
{
	        /// <summary>
	        /// 用户信息
	        /// </summary>
	        [XmlElement("accountInfo")]
	        public AccountInfoDomain AccountInfo { get; set; }
}

        #endregion
    }
}
