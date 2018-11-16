using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.Sample;
namespace Model.Sample
{
   public  class SampleReturn : BaseModel, ISampleReturn
    {

        public int Id { get; set; }
        /// <summary>
        /// 借出单号
        /// </summary>
        public string ReturnNo { get; set; }
        /// <summary>
        /// 借出人ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 还回人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 还回部门
        /// </summary>
        public string UserDept { get; set; }

        /// <summary>
        /// 还回单状态
        /// </summary>
        public ReturnStats Satas { get; set; }
        
    }
  
}
