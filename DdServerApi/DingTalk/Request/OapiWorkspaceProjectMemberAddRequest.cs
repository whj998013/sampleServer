using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.workspace.project.member.add
    /// </summary>
    public class OapiWorkspaceProjectMemberAddRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiWorkspaceProjectMemberAddResponse>
    {
        /// <summary>
        /// 添加成员 最多20个
        /// </summary>
        public string Members { get; set; }

        public List<OpenMemberAddDtoDomain> Members_ { set { this.Members = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.workspace.project.member.add";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("members", this.Members);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("members", this.Members);
            RequestValidator.ValidateObjectMaxListSize("members", this.Members, 20);
        }

	/// <summary>
/// OpenMemberAddDtoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenMemberAddDtoDomain : TopObject
{
	        /// <summary>
	        /// 手机号
	        /// </summary>
	        [XmlElement("mobile")]
	        public string Mobile { get; set; }
	
	        /// <summary>
	        /// 国家码
	        /// </summary>
	        [XmlElement("state_code")]
	        public string StateCode { get; set; }
	
	        /// <summary>
	        /// 长度4-32位之间，仅允许（字母 数字 _ -）
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

        #endregion
    }
}
