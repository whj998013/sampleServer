using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.corp.smartdevice.addrecognizenotify
    /// </summary>
    public class CorpSmartdeviceAddrecognizenotifyRequest : BaseDingTalkRequest<DingTalk.Api.Response.CorpSmartdeviceAddrecognizenotifyResponse>
    {
        /// <summary>
        /// 通知数据
        /// </summary>
        public string NotifyVo { get; set; }

        public RecognizeNotifyVODomain NotifyVo_ { set { this.NotifyVo = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.corp.smartdevice.addrecognizenotify";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_TOP;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("notify_vo", this.NotifyVo);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("notify_vo", this.NotifyVo);
        }

	/// <summary>
/// RecognizeNotifyVODomain Data Structure.
/// </summary>
[Serializable]

public class RecognizeNotifyVODomain : TopObject
{
	        /// <summary>
	        /// 预约开始时间 timestamp(毫秒)
	        /// </summary>
	        [XmlElement("appointed_endtime")]
	        public Nullable<long> AppointedEndtime { get; set; }
	
	        /// <summary>
	        /// 预约结束时间 timestamp(毫秒)
	        /// </summary>
	        [XmlElement("appointed_starttime")]
	        public Nullable<long> AppointedStarttime { get; set; }
	
	        /// <summary>
	        /// 消息内容的模板，key向智能硬件团队申请
	        /// </summary>
	        [XmlElement("notify_template")]
	        public string NotifyTemplate { get; set; }
	
	        /// <summary>
	        /// 通知类型 仅支持1：用户
	        /// </summary>
	        [XmlElement("notify_type")]
	        public Nullable<long> NotifyType { get; set; }
	
	        /// <summary>
	        /// 被通知的用户列表
	        /// </summary>
	        [XmlArray("notify_user_list")]
	        [XmlArrayItem("string")]
	        public List<string> NotifyUserList { get; set; }
	
	        /// <summary>
	        /// 识别结束时间 timestamp(毫秒)
	        /// </summary>
	        [XmlElement("recognize_endtime")]
	        public Nullable<long> RecognizeEndtime { get; set; }
	
	        /// <summary>
	        /// 识别开始时间 timestamp(毫秒)
	        /// </summary>
	        [XmlElement("recognize_starttime")]
	        public Nullable<long> RecognizeStarttime { get; set; }
	
	        /// <summary>
	        /// 联系人id
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

        #endregion
    }
}
