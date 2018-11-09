using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.impaas.group.create
    /// </summary>
    public class OapiImpaasGroupCreateRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiImpaasGroupCreateResponse>
    {
        /// <summary>
        /// 创建群请求对象
        /// </summary>
        public string Request { get; set; }

        public CreateGroupRequestDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.impaas.group.create";
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
	        /// 账号id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 账号类型
	        /// </summary>
	        [XmlElement("type")]
	        public string Type { get; set; }
}

	/// <summary>
/// CreateGroupRequestDomain Data Structure.
/// </summary>
[Serializable]

public class CreateGroupRequestDomain : TopObject
{
	        /// <summary>
	        /// hema
	        /// </summary>
	        [XmlElement("channel")]
	        public string Channel { get; set; }
	
	        /// <summary>
	        /// 创建者
	        /// </summary>
	        [XmlElement("creater")]
	        public BaseGroupMemberInfoDomain Creater { get; set; }
	
	        /// <summary>
	        /// 扩展数据
	        /// </summary>
	        [XmlElement("extension")]
	        public string Extension { get; set; }
	
	        /// <summary>
	        /// 群成员列表
	        /// </summary>
	        [XmlArray("member_list")]
	        [XmlArrayItem("base_group_member_info")]
	        public List<BaseGroupMemberInfoDomain> MemberList { get; set; }
	
	        /// <summary>
	        /// 群名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 群类型
	        /// </summary>
	        [XmlElement("type")]
	        public Nullable<long> Type { get; set; }
}

        #endregion
    }
}
