
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sample;

namespace SampleBLL.Model
{
    public class SeachModel
    {
        [DataMember(Name = "current")]
        public int Current { get; set; }

        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "pageSize")]

        public int PageSize { get; set; }

        [DataMember(Name = "keyWord")]

        public string KeyWord { get; set; }

        [DataMember(Name = "dateValue")]

        public DateTime[] DateValue { get; set; }


        [DataMember(Name = "state")]
        public SampleState State { get; set; }

        [DataMember(Name = "userId")]
        public List<string> UserId { get; set; }
    }
}
