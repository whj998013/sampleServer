using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.workspace.project.role.create
    /// </summary>
    public class OapiWorkspaceProjectRoleCreateRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiWorkspaceProjectRoleCreateResponse>
    {
        /// <summary>
        /// 创建角色参数
        /// </summary>
        public string Tags { get; set; }

        public List<OpenTagCreateDtoDomain> Tags_ { set { this.Tags = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.workspace.project.role.create";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("tags", this.Tags);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("tags", this.Tags);
            RequestValidator.ValidateObjectMaxListSize("tags", this.Tags, 20);
        }

	/// <summary>
/// OpenTagCreateDtoDomain Data Structure.
/// </summary>
[Serializable]

public class OpenTagCreateDtoDomain : TopObject
{
	        /// <summary>
	        /// 角色名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
}

        #endregion
    }
}
