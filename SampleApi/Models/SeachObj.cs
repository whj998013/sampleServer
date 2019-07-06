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
        [DataMember(Name = "deptIdList")]
        public List<long> DeptIdList { get; set; } = new List<long>();
        [DataMember(Name = "limits")]
        public List<Limit> Limits { get; set; }
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

    public class Limit
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}