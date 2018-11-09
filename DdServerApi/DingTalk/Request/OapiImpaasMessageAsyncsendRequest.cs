using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.impaas.message.asyncsend
    /// </summary>
    public class OapiImpaasMessageAsyncsendRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiImpaasMessageAsyncsendResponse>
    {
        /// <summary>
        /// 消息发送的信息
        /// </summary>
        public string Request { get; set; }

        public AsyncSendMessageRequestDomain Request_ { set { this.Request = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.impaas.message.asyncsend";
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
	        /// 账号通道
	        /// </summary>
	        [XmlElement("channel")]
	        public string Channel { get; set; }
	
	        /// <summary>
	        /// 账号ID
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
/// XpnContentModelDomain Data Structure.
/// </summary>
[Serializable]

public class XpnContentModelDomain : TopObject
{
	        /// <summary>
	        /// 推送文案
	        /// </summary>
	        [XmlElement("alert_content")]
	        public string AlertContent { get; set; }
	
	        /// <summary>
	        /// 推送参数
	        /// </summary>
	        [XmlElement("params")]
	        public string Params { get; set; }
}

	/// <summary>
/// AsyncSendMessageRequestDomain Data Structure.
/// </summary>
[Serializable]

public class AsyncSendMessageRequestDomain : TopObject
{
	        /// <summary>
	        /// 群ID
	        /// </summary>
	        [XmlElement("group_id")]
	        public string GroupId { get; set; }
	
	        /// <summary>
	        /// 消息内容，根据msgtype不同，解析方式不同
	        /// </summary>
	        [XmlElement("msg_content")]
	        public string MsgContent { get; set; }
	
	        /// <summary>
	        /// 消息的可扩展字段
	        /// </summary>
	        [XmlElement("msg_extension")]
	        public string MsgExtension { get; set; }
	
	        /// <summary>
	        /// 消息的特性：静默消息，单边消息等
	        /// </summary>
	        [XmlElement("msg_feature")]
	        public string MsgFeature { get; set; }
	
	        /// <summary>
	        /// 消息类型：text，image
	        /// </summary>
	        [XmlElement("msg_type")]
	        public string MsgType { get; set; }
	
	        /// <summary>
	        /// 接受者
	        /// </summary>
	        [XmlArray("receiverid_list")]
	        [XmlArrayItem("json")]
	        public List<string> ReceiveridList { get; set; }
	
	        /// <summary>
	        /// 发送者
	        /// </summary>
	        [XmlElement("senderid")]
	        public AccountInfoDomain Senderid { get; set; }
	
	        /// <summary>
	        /// 推送信息
	        /// </summary>
	        [XmlElement("xpn_model")]
	        public XpnContentModelDomain XpnModel { get; set; }
}

        #endregion
    }
}
