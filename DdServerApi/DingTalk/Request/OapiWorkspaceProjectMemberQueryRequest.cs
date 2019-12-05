using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.workspace.project.member.query
    /// </summary>
    public class OapiWorkspaceProjectMemberQueryRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiWorkspaceProjectMemberQueryResponse>
    {
        /// <summary>
        /// 查询项目成员参数 最多20个
        /// </summary>
        public string Members { get; set; }

        public List<OpenMemberQueryDtoDomain> Members_ { set { this.Members = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.workspace.project.member.query";
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
/// OpenMemberQueryDtoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenMemberQueryDtoDomain : TopObject
{
	        /// <summary>
	        /// 成员id
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

        #endregion
    }
}
