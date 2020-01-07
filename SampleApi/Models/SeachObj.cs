using SG.Interface.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SampleApi
{
    public class SeachObj
    {
        private int pid = 1;
        private int pSize = 20;
        [DataMember(Name = "key")]
        public string Key{get; set;}
        [DataMember(Name = "pageId")]
        public int PageId
        {
            get
            {
                return pid;
            }
            set
            {
                if (value < 1) pid = 1;
                else pid = value;
            }
        }
        [DataMember(Name = "pageSize")]
        public int PageSize
        {
            get
            {
                return pSize;
            }
            set
            {
                if (value < 1) pSize = 10;
                else pSize = value;
            }
        }
        [DataMember(Name = "total")]
        public int Total { get; set; }
        [DataMember(Name = "beginDate")]
        public DateTime? BeginDate { get; set; }
        [DataMember(Name = "endDate")]
        public DateTime? EndDate { get; set; }
        [DataMember(Name = "getAll")]
        public bool GetAll { get; set; }

    }
    public class SeachObjSample : SeachObj
    {
        [DataMember(Name = "userId")]
        public List<string> UserId { get; set; }

        [DataMember(Name = "inUserId")]
        public List<string> InUserId { get; set; }
        
        [DataMember(Name = "state")]
        public SampleState State { get; set; }
    }

    public class SeachObjDept : SeachObj
    {
        [DataMember(Name = "deptIdList")]
        public List<long> DeptIdList { get; set; } = new List<long>();
        [DataMember(Name = "getAllDept")]
        public bool GetAllDept { get; set; }
    }
    public class SeachObjDeptAndState: SeachObjDept
    {
        [DataMember(Name ="state")]
        public int State { get; set; }
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