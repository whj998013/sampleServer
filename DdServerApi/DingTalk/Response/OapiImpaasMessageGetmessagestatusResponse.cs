using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiImpaasMessageGetmessagestatusResponse.
    /// </summary>
    public class OapiImpaasMessageGetmessagestatusResponse : DingTalkResponse
    {
        /// <summary>
        /// dingOpenErrcode
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// errorMsg
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public GetMessageStatusResponseDomain Result { get; set; }

	/// <summary>
/// FailedModelDomain Data Structure.
/// </summary>
[Serializable]

public class FailedModelDomain : TopObject
{
	        /// <summary>
	        /// code
	        /// </summary>
	        [XmlElement("code")]
	        public string Code { get; set; }
	
	        /// <summary>
	        /// msg
	        /// </summary>
	        [XmlElement("msg")]
	        public string Msg { get; set; }
	
	        /// <summary>
	        /// receiverId
	        /// </summary>
	        [XmlElement("receiver_id")]
	        public string ReceiverId { get; set; }
}

	/// <summary>
/// ReadModelDomain Data Structure.
/// </summary>
[Serializable]

public class ReadModelDomain : TopObject
{
	        /// <summary>
	        /// readTime
	        /// </summary>
	        [XmlElement("read_time")]
	        public long ReadTime { get; set; }
	
	        /// <summary>
	        /// receiverId
	        /// </summary>
	        [XmlElement("receiver_id")]
	        public string ReceiverId { get; set; }
}

	/// <summary>
/// GetMessageStatusResponseDomain Data Structure.
/// </summary>
[Serializable]

public class GetMessageStatusResponseDomain : TopObject
{
	        /// <summary>
	        /// 发送失败的详情 receiverId：失败的id code：失败的错误码 msg：失败的原因
	        /// </summary>
	        [XmlArray("failed_model")]
	        [XmlArrayItem("failed_model")]
	        public List<FailedModelDomain> FailedModel { get; set; }
	
	        /// <summary>
	        /// 已读的接收者及时间列表 receiverId：用户id readTime：阅读时间，Long
	        /// </summary>
	        [XmlArray("read_model")]
	        [XmlArrayItem("read_model")]
	        public List<ReadModelDomain> ReadModel { get; set; }
	
	        /// <summary>
	        /// 消息任务执行返回码 0表示成功
	        /// </summary>
	        [XmlElement("task_code")]
	        public long TaskCode { get; set; }
	
	        /// <summary>
	        /// 错误信息
	        /// </summary>
	        [XmlElement("task_msg")]
	        public string TaskMsg { get; set; }
	
	        /// <summary>
	        /// 消息任务执行状态 0：初始化，刚提交时的状态 3：处理中 4：处理完成 5：撤销
	        /// </summary>
	        [XmlElement("task_status")]
	        public long TaskStatus { get; set; }
}

    }
}
