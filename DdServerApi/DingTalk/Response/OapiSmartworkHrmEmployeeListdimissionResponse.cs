using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiSmartworkHrmEmployeeListdimissionResponse.
    /// </summary>
    public class OapiSmartworkHrmEmployeeListdimissionResponse : DingTalkResponse
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
        /// 数据结果
        /// </summary>
        [XmlArray("result")]
        [XmlArrayItem("emp_dimission_info_vo")]
        public List<EmpDimissionInfoVoDomain> Result { get; set; }

        /// <summary>
        /// success
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// EmpDeptVODomain Data Structure.
/// </summary>
[Serializable]

public class EmpDeptVODomain : TopObject
{
	        /// <summary>
	        /// 部门id
	        /// </summary>
	        [XmlElement("dept_id")]
	        public long DeptId { get; set; }
	
	        /// <summary>
	        /// 部门路径
	        /// </summary>
	        [XmlElement("dept_path")]
	        public string DeptPath { get; set; }
}

	/// <summary>
/// EmpDimissionInfoVoDomain Data Structure.
/// </summary>
[Serializable]

public class EmpDimissionInfoVoDomain : TopObject
{
	        /// <summary>
	        /// 离职部门列表
	        /// </summary>
	        [XmlArray("dept_list")]
	        [XmlArrayItem("emp_dept_v_o")]
	        public List<EmpDeptVODomain> DeptList { get; set; }
	
	        /// <summary>
	        /// 最后工作日
	        /// </summary>
	        [XmlElement("last_work_day")]
	        public long LastWorkDay { get; set; }
	
	        /// <summary>
	        /// 员工id
	        /// </summary>
	        [XmlElement("userid")]
	        public string Userid { get; set; }
}

    }
}
