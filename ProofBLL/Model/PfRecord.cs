using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofBLL.Model
{
  public  class PfRecord
    {
        public string ProcessName { get; set; }
        public string WorkerName { get; set; }
        /// <summary>
        /// 工时
        /// </summary>
        public int WorkTime { get; set; }
        public DateTime? BeginDate { get; set; }

        public DateTime? FinshDate { get; set; }

    }
}
