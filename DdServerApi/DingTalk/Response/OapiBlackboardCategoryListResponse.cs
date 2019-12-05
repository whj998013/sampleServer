using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiBlackboardCategoryListResponse.
    /// </summary>
    public class OapiBlackboardCategoryListResponse : DingTalkResponse
    {
        /// <summary>
        /// 请求失败返回错误码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 请求失败返回错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 出参
        /// </summary>
        [XmlArray("result")]
        [XmlArrayItem("blackboard_category_vo")]
        public List<BlackboardCategoryVoDomain> Result { get; set; }

        /// <summary>
        /// 请求成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// BlackboardCategoryVoDomain Data Structure.
/// </summary>
[Serializable]

public class BlackboardCategoryVoDomain : TopObject
{
	        /// <summary>
	        /// 分类id
	        /// </summary>
	        [XmlElement("id")]
	        public string Id { get; set; }
	
	        /// <summary>
	        /// 分类名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
}

    }
}
