using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiSmartworkHrmEmployeeListResponse.
    /// </summary>
    public class OapiSmartworkHrmEmployeeListResponse : DingTalkResponse
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
        /// 返回结果
        /// </summary>
        [XmlArray("result")]
        [XmlArrayItem("emp_field_info_vo")]
        public List<EmpFieldInfoVoDomain> Result { get; set; }

        /// <summary>
        /// 调用是否成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// EmpFieldInfoVoDomain Data Structure.
/// </summary>
[Serializable]

public class EmpFieldInfoVoDomain : TopObject
{
	        /// <summary>
	        /// 字段编码
	        /// </summary>
	        [XmlElement("field_code")]
	        public string FieldCode { get; set; }
	
	        /// <summary>
	        /// 字段名称
	        /// </summary>
	        [XmlElement("field_name")]
	        public string FieldName { get; set; }
	
	        /// <summary>
	        /// 字段业务分组
	        /// </summary>
	        [XmlElement("group_id")]
	        public string GroupId { get; set; }
	
	        /// <summary>
	        /// 字段值
	        /// </summary>
	        [XmlElement("value")]
	        public string Value { get; set; }
}

    }
}
