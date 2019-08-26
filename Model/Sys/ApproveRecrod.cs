using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Sys
{
    public class ApproveRecrod
    {
        public int Id { get; set; }
        /// <summary>
        /// 申请名
        /// </summary>
        public string ApproveName { get; set; }
        /// <summary>
        /// 钉钉申请号
        /// </summary>
        public string ApproveCode { get; set; }
        /// <summary>
        /// 对象id
        /// </summary>
        public string ObjId { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime? ApproveDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? FinshDate { get; set; }
        /// <summary>
        /// 是否结束
        /// </summary>
        public bool Finshed { get; set; }
        /// <summary>
        /// 是否同意
        /// </summary>
        public bool Agree { get; set; }
    }
}
