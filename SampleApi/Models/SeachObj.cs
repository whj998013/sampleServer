using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SampleApi
{
    public class SeachObj
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }
        [DataMember(Name = "pageId")]
        public int PageId { get; set; }
        [DataMember(Name = "pageSize")]
        public int PageSize { get; set; }
        [DataMember(Name = "total")]
        public int Total { get; set; }
        [DataMember(Name = "beginDate")]
        public DateTime? BeginDate { get; set; }
        [DataMember(Name = "endDate")]
        public DateTime? EndDate { get; set; }
    }

    public class SeachObjDept : SeachObj
    {
        [DataMember(Name = "deptIdList")]
        public List<long> DeptIdList { get; set; } = new List<long>();
    }
    public class SeachObjLab : SeachObj
    {
        [DataMember(Name = "lab")]
        public Lab Lab { get; set; }
    }

    public class SeachReturnObj
    {
        public object Result { get; set; }

        public SeachObj SeachObj { get; set; }

    }

    public class Lab
    {
        [DataMember(Name = "l")]
        public double L { get; set; }
        [DataMember(Name = "a")]

        public double A { get; set; }
        [DataMember(Name = "b")]

        public double B { get; set; }


    }


}