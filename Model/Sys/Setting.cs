using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.Sys;

namespace Model.Sys
{
   public  class Setting : ISetting
    {
        public int Id { get; set; }

        public string KeyName { get; set; }

        public string KeyValue { get; set; }

        public string Remark { get; set; }

    }
}
