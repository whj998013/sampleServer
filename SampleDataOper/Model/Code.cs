using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataOper.Model
{
    public class Code : BaseModel
    {
        public int Id { get; set; }

        public CodeType Type { get; set; }

        public string CodeName { get; set; }

        public string Value1 { get; set; }

        public string Value2 { get; set; }

        public string Value3 { get; set; }


        public int UseCount { get; set; }
    }

    public enum CodeType
    {
        Color = 1,
        Size = 2,
        Gauge = 3,
        Material = 4,
        Tag = 5,
        Kinds=6,
    }
}
