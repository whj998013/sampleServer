using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiEduFaceSearchResponse.
    /// </summary>
    public class OapiEduFaceSearchResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// response
        /// </summary>
        [XmlElement("result")]
        public TopSubmitFaceSearchResponseDomain Result { get; set; }

        /// <summary>
        /// 调用是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// TopSubmitFaceSearchResponseDomain Data Structure.
/// </summary>
[Serializable]

public class TopSubmitFaceSearchResponseDomain : TopObject
{
	        /// <summary>
	        /// task id
	        /// </summary>
	        [XmlElement("task_id")]
	        public string TaskId { get; set; }
}

    }
}
