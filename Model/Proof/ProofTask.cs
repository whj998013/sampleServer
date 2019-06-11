using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
namespace SG.Model.Proof
{
    public class ProofTask : BaseModel
    {
        public int Id { get; set; }

        public string TaskNo { get; set; }
        public string UpTaskNo { get; set; }
        public string UserName { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual Process Process { get; set; }

        public virtual ProofOrder Order { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 通用状态
        /// </summary>
        public Stats Stats { get; set; }
        /// <summary>
        /// 工作文件
        /// </summary>
        public List<ProofFile> TaskFiles { get; set; } = new List<ProofFile>();

        public DateTime? BeginDate { get; set; }
        public DateTime? NeedFinshDate { get; set; }

        public DateTime? FinshDate { get; set; }
    }
}
