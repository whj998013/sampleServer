using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.impaas.groupmember.modify
    /// </summary>
    public class OapiImpaasGroupmemberModifyRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiImpaasGroupmemberModifyResponse>
    {
        /// <summary>
        /// 修改群成员列表入参
        /// </summary>
        public string Request { get; set; }

        public GroupMemberListModifyRequestDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.impaas.groupmember.modify";
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
	        /// 待成员id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 待操作成员类型
	        /// </summary>
	        [XmlElement("type")]
	        public string Type { get; set; }
}

	/// <summary>
/// GroupMemberListModifyRequestDomain Data Structure.
/// </summary>
[Serializable]

public class GroupMemberListModifyRequestDomain : TopObject
{
	        /// <summary>
	        /// 渠道号
	        /// </summary>
	        [XmlElement("channel")]
	        public string Channel { get; set; }
	
	        /// <summary>
	        /// 会话id
	        /// </summary>
	        [XmlElement("chatid")]
	        public string Chatid { get; set; }
	
	        /// <summary>
	        /// 待操作成员列表
	        /// </summary>
	        [XmlArray("member_list")]
	        [XmlArrayItem("base_group_member_info")]
	        public List<BaseGroupMemberInfoDomain> MemberList { get; set; }
	
	        /// <summary>
	        /// 表示添加或删除
	        /// </summary>
	        [XmlElement("modify_type")]
	        public string ModifyType { get; set; }
}

        #endregion
    }
}
