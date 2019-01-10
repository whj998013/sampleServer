using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Proof
{
    /// <summary>
    /// 打样款式信息
    /// </summary>
    public class ProofStyle: BaseModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 款式ID
        /// </summary>
        public string ProofStyleId { get; set; }

        /// <summary>
        /// 打样类别：初样、修改样
        /// </summary>
        public ProofType ProofType { get; set; }       
        // <summary>
        /// 款号
        /// </summary>
        public string ProofStyleNo { get; set; }
        /// <summary>
        /// 客户名
        /// </summary>
        public string ClentName { get; set; }
        /// <summary>
        /// 客户款号
        /// </summary>
        public string ClientNo { get; set; }
        /// <summary>
        /// 款名
        /// </summary>
        public string StyleName { get; set; }
        /// <summary>
        /// 支数
        /// </summary>
        public string Counts { get; set; }
        /// <summary>
        /// 原料成份
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 克重
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// 针型
        /// </summary>
        public string Gauge { get; set; }
        
    }
}
