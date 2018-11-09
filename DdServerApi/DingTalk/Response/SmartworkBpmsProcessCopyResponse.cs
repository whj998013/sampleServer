using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// SmartworkBpmsProcessCopyResponse.
    /// </summary>
    public class SmartworkBpmsProcessCopyResponse : DingTalkResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public DingOpenResultDomain Result { get; set; }

	/// <summary>
/// ProcessVoDomain Data Structure.
/// </summary>
[Serializable]

public class ProcessVoDomain : TopObject
{
	        /// <summary>
	        /// bizCategoryId
	        /// </summary>
	        [XmlElement("biz_category_id")]
	        public string BizCategoryId { get; set; }
	
	        /// <summary>
	        /// description
	        /// </summary>
	        [XmlElement("description")]
	        public string Description { get; set; }
	
	        /// <summary>
	        /// formContent
	        /// </summary>
	        [XmlElement("form_content")]
	        public string FormContent { get; set; }
	
	        /// <summary>
	        /// name
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// processCode
	        /// </summary>
	        [XmlElement("process_code")]
	        public string ProcessCode { get; set; }
}

	/// <summary>
/// DingOpenResultDomain Data Structure.
/// </summary>
[Serializable]

public class DingOpenResultDomain : TopObject
{
	        /// <summary>
	        /// dingOpenErrcode
	        /// </summary>
	        [XmlElement("ding_open_errcode")]
	        public long DingOpenErrcode { get; set; }
	
	        /// <summary>
	        /// errorMsg
	        /// </summary>
	        [XmlElement("error_msg")]
	        public string ErrorMsg { get; set; }
	
	        /// <summary>
	        /// result
	        /// </summary>
	        [XmlElement("result")]
	        public ProcessVoDomain Result { get; set; }
	
	        /// <summary>
	        /// success
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
