using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// CorpDingindexGetResponse.
    /// </summary>
    public class CorpDingindexGetResponse : DingTalkResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [XmlElement("result")]
        public DingOpenResultDomain Result { get; set; }

	/// <summary>
/// DingIndexVoDomain Data Structure.
/// </summary>
[Serializable]

public class DingIndexVoDomain : TopObject
{
	        /// <summary>
	        /// 月平均钉钉指数
	        /// </summary>
	        [XmlElement("avarage_month_index")]
	        public string AvarageMonthIndex { get; set; }
	
	        /// <summary>
	        /// 日钉钉指数
	        /// </summary>
	        [XmlElement("day_index")]
	        public string DayIndex { get; set; }
	
	        /// <summary>
	        /// 统计时间
	        /// </summary>
	        [XmlElement("stat_date")]
	        public string StatDate { get; set; }
}

	/// <summary>
/// DingOpenResultDomain Data Structure.
/// </summary>
[Serializable]

public class DingOpenResultDomain : TopObject
{
	        /// <summary>
	        /// result
	        /// </summary>
	        [XmlArray("ding_index_list")]
	        [XmlArrayItem("ding_index_vo")]
	        public List<DingIndexVoDomain> DingIndexList { get; set; }
	
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
	        /// success
	        /// </summary>
	        [XmlElement("success")]
	        public bool Success { get; set; }
}

    }
}
