using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;

namespace SG.Model.Sys
{
    /// <summary>
    /// SampleInfo为样品信息，SampleLend为借出单，Stock为库存单
    /// </summary>
    public class Km : IKm
    {
        public int Id { get; set; }
        public string KeyName { get; set; }
        public int KeyValue { get; set; }
        public string BeginKey { get; set; }
        public string Comment { get; set; }

    }

   
}
