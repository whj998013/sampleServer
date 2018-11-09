using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.smartwork.bpms.processinstance.updatevariables
    /// </summary>
    public class SmartworkBpmsProcessinstanceUpdatevariablesRequest : BaseDingTalkRequest<DingTalk.Api.Response.SmartworkBpmsProcessinstanceUpdatevariablesResponse>
    {
        /// <summary>
        /// 审批实例id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 表单参数列表
        /// </summary>
        public string Variables { get; set; }

        public List<BizValueVoDomain> Variables_ { set { this.Variables = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.smartwork.bpms.processinstance.updatevariables";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_TOP;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("process_instance_id", this.ProcessInstanceId);
            parameters.Add("remark", this.Remark);
            parameters.Add("variables", this.Variables);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("process_instance_id", this.ProcessInstanceId);
            RequestValidator.ValidateRequired("variables", this.Variables);
            RequestValidator.ValidateObjectMaxListSize("variables", this.Variables, 5);
        }

	/// <summary>
/// BizValueVoDomain Data Structure.
/// </summary>
[Serializable]

public class BizValueVoDomain : TopObject
{
	        /// <summary>
	        /// 别名，审批表单控件唯一标识
	        /// </summary>
	        [XmlElement("biz_alias")]
	        public string BizAlias { get; set; }
	
	        /// <summary>
	        /// 扩展值
	        /// </summary>
	        [XmlElement("ext_value")]
	        public string ExtValue { get; set; }
	
	        /// <summary>
	        /// 表单值
	        /// </summary>
	        [XmlElement("value")]
	        public string Value { get; set; }
}

        #endregion
    }
}
