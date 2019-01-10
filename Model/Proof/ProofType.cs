using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Proof
{
    public class ProofType
    {
        public int Id { get; set; }
        /// <summary>
        /// 初样、修改样、推销样
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 打样价格
        /// </summary>
        public float ProofPrice { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remork { get; set; }
    }
}
