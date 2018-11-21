using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sample;
namespace Model.Sample
{
    /// <summary>
    /// 样衣借出记录
    /// </summary>
    public class LendRecord : BaseModel, ILendRecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 样衣ID
        /// </summary>
        public string StyleId { get; set; }
        /// <summary>
        /// 钉钉ID
        /// </summary>
        public string DdId { get; set; }
        /// <summary>
        /// 借出人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 借出部门
        /// </summary>
        public string UserDept { get; set; }
        /// <summary>
        /// 借出日期
        /// </summary>
        public DateTime? LendOutDate { get; set; }

        /// <summary>
        /// 借出审批单ID
        /// </summary>
        public string LendOutNo { get; set; }
        /// <summary>
        /// 还回日期
        /// </summary>
        public DateTime? ReturnDate { get; set; }
        /// <summary>
        /// 还回单Id
        /// </summary>
        public string ReturnNo { get; set; }
       
        public LendRecordStats State { get; set; }
    }

}
