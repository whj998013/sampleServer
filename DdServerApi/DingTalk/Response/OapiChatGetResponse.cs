using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiChatGetResponse.
    /// </summary>
    public class OapiChatGetResponse : DingTalkResponse
    {
        /// <summary>
        /// chat_info
        /// </summary>
        [XmlElement("chat_info")]
        public ChatInfoDomain ChatInfo { get; set; }

        /// <summary>
        /// errcode
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// errmsg
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

	/// <summary>
/// ChatInfoDomain Data Structure.
/// </summary>
[Serializable]

public class ChatInfoDomain : TopObject
{
	        /// <summary>
	        /// agentidlist
	        /// </summary>
	        [XmlArray("agentidlist")]
	        [XmlArrayItem("string")]
	        public List<string> Agentidlist { get; set; }
	
	        /// <summary>
	        /// conversationTag
	        /// </summary>
	        [XmlElement("conversationTag")]
	        public long ConversationTag { get; set; }
	
	        /// <summary>
	        /// extidlist
	        /// </summary>
	        [XmlArray("extidlist")]
	        [XmlArrayItem("string")]
	        public List<string> Extidlist { get; set; }
	
	        /// <summary>
	        /// name
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// owner
	        /// </summary>
	        [XmlElement("owner")]
	        public string Owner { get; set; }
	
	        /// <summary>
	        /// useridlist
	        /// </summary>
	        [XmlArray("useridlist")]
	        [XmlArrayItem("string")]
	        public List<string> Useridlist { get; set; }
}

    }
}
