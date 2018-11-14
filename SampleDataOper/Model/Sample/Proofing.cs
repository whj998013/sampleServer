using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataOper.Model
{
    /// <summary>
    /// 打样信息表
    /// </summary>
    public class Proofing : BaseModel
    {
        public int Id { get; set; }

        public string StyleId { get; set; }
        /// <summary>
        /// 样品生产单们
        /// </summary>
        public string ProofingCompany { get; set; }
        /// <summary>
        /// 机器种类
        /// </summary>
        public string MachineType { get; set; }
        /// <summary>
        /// 机织时间
        /// </summary>
        public int WeaveTime { get; set; }
        /// <summary>
        /// 工艺员
        /// </summary>
        public string TechnologyPeople { get; set; }
        /// <summary>
        /// 程序员
        /// </summary>
        public string ProgamPeople { get; set; }
        /// <summary>
        /// 样衣生产日期
        /// </summary>
        public DateTime? ProofingDate { get; set; }



    }
}
