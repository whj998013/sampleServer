using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;

namespace SG.Model.Sys
{
    public class Code : BaseModel, ICode
    {
        public int Id { get; set; }

        public CodeType Type { get; set; }

        public string CodeName { get; set; }

        public string Value1 { get; set; }

        public string Value2 { get; set; }

        public string Value3 { get; set; }


        public int UseCount { get; set; }
    }

 
}
