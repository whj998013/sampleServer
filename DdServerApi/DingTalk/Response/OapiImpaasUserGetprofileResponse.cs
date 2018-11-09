using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiImpaasUserGetprofileResponse.
    /// </summary>
    public class OapiImpaasUserGetprofileResponse : DingTalkResponse
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
        public GetProfileRespDomain Result { get; set; }

        /// <summary>
        /// success
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// GetProfileRespDomain Data Structure.
/// </summary>
[Serializable]

public class GetProfileRespDomain : TopObject
{
	        /// <summary>
	        /// avatarMediaId
	        /// </summary>
	        [XmlElement("avatar_mediaid")]
	        public string AvatarMediaid { get; set; }
	
	        /// <summary>
	        /// extension
	        /// </summary>
	        [XmlElement("extension")]
	        public string Extension { get; set; }
	
	        /// <summary>
	        /// imOpenId
	        /// </summary>
	        [XmlElement("im_openid")]
	        public string ImOpenid { get; set; }
	
	        /// <summary>
	        /// nick
	        /// </summary>
	        [XmlElement("nick")]
	        public string Nick { get; set; }
}

    }
}
