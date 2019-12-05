using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiAttendanceGroupQueryResponse.
    /// </summary>
    public class OapiAttendanceGroupQueryResponse : DingTalkResponse
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
        /// demo
        /// </summary>
        [XmlElement("result")]
        public TopSimpleGroupVODomain Result { get; set; }

        /// <summary>
        /// 成功标记
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// TopSimpleGroupVODomain Data Structure.
/// </summary>
[Serializable]

public class TopSimpleGroupVODomain : TopObject
{
	        /// <summary>
	        /// 考勤地址
	        /// </summary>
	        [XmlArray("address_list")]
	        [XmlArrayItem("string")]
	        public List<string> AddressList { get; set; }
	
	        /// <summary>
	        /// id
	        /// </summary>
	        [XmlElement("id")]
	        public long Id { get; set; }
	
	        /// <summary>
	        /// 考勤组管理员
	        /// </summary>
	        [XmlElement("manager_list")]
	        public string ManagerList { get; set; }
	
	        /// <summary>
	        /// 人员人数
	        /// </summary>
	        [XmlElement("member_count")]
	        public long MemberCount { get; set; }
	
	        /// <summary>
	        /// 名称
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 固定值，轮班制
	        /// </summary>
	        [XmlElement("type")]
	        public string Type { get; set; }
	
	        /// <summary>
	        /// 跳转链接
	        /// </summary>
	        [XmlElement("url")]
	        public string Url { get; set; }
	
	        /// <summary>
	        /// wifi名称
	        /// </summary>
	        [XmlArray("wifis")]
	        [XmlArrayItem("string")]
	        public List<string> Wifis { get; set; }
	
	        /// <summary>
	        /// 工作日
	        /// </summary>
	        [XmlArray("work_day_list")]
	        [XmlArrayItem("number")]
	        public List<long> WorkDayList { get; set; }
}

    }
}
