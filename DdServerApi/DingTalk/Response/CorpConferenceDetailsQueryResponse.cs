using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// CorpConferenceDetailsQueryResponse.
    /// </summary>
    public class CorpConferenceDetailsQueryResponse : DingTalkResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }

    }
}
