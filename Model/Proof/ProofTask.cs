using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
namespace SG.Model.Proof
{
    public class ProofTask:BaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Worker Worker { get; set; }
        public Process Process { get; set; }

        public ProofOrder Order { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }

        public DateTime? BeginDate { get; set; }
        public DateTime? NeedFinshDate { get; set; }

        public DateTime? FinshDate { get; set; }
    }
}
