using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sample;
namespace SG.Model.Sample
{
    /// <summary>
    ///  借出单
    /// </summary>
    public class SampleLendout : BaseModel, ISampleLendout
    {
        public int Id { get; set; }

        /// <summary>
        /// 借出单号
        /// </summary>
        public string LendOutNo { get; set; }
      

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
        /// 借用单状态
        /// </summary>
        public LendStats State { get; set; }
    }
 
}
