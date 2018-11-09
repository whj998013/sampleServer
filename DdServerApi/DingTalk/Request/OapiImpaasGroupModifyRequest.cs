using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.impaas.group.modify
    /// </summary>
    public class OapiImpaasGroupModifyRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiImpaasGroupModifyResponse>
    {
        /// <summary>
        /// 请求入参
        /// </summary>
        public string Request { get; set; }

        public GroupInfoModifyRequestDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.impaas.group.modify";
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
/// BaseGroupMemberInfoDomain Data Structure.
/// </summary>
[Serializable]

public class BaseGroupMemberInfoDomain : TopObject
{
	        /// <summary>
	        /// 群主id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// id类型 员工or openid
	        /// </summary>
	        [XmlElement("type")]
	        public string Type { get; set; }
}

	/// <summary>
/// GroupInfoModifyRequestDomain Data Structure.
/// </summary>
[Serializable]

public class GroupInfoModifyRequestDomain : TopObject
{
	        /// <summary>
	        /// 会话id
	        /// </summary>
	        [XmlElement("chatid")]
	        public string Chatid { get; set; }
	
	        /// <summary>
	        /// 群名称
	        /// </summary>
	        [XmlElement("group_name")]
	        public string GroupName { get; set; }
	
	        /// <summary>
	        /// 群主信息
	        /// </summary>
	        [XmlElement("group_owner")]
	        public BaseGroupMemberInfoDomain GroupOwner { get; set; }
}

        #endregion
    }
}
