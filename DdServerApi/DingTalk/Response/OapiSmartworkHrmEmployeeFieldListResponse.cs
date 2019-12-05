using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiSmartworkHrmEmployeeFieldListResponse.
    /// </summary>
    public class OapiSmartworkHrmEmployeeFieldListResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 结果集
        /// </summary>
        [XmlArray("result")]
        [XmlArrayItem("emp_field_vo")]
        public List<EmpFieldVoDomain> Result { get; set; }

        /// <summary>
        /// 成功标记
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// EmpFieldVoDomain Data Structure.
/// </summary>
[Serializable]

public class EmpFieldVoDomain : TopObject
{
	        /// <summary>
	        /// 字段code
	        /// </summary>
	        [XmlElement("field_code")]
	        public string FieldCode { get; set; }
	
	        /// <summary>
	        /// 字段描述
	        /// </summary>
	        [XmlElement("field_name")]
	        public string FieldName { get; set; }
}

    }
}
