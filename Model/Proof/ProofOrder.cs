using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;

namespace SG.Model.Proof
{
    /// <summary>
    /// 打样申请单
    /// </summary>
    public class ProofOrder : BaseModel
    {

        public int Id { get; set; }
        /// <summary>
        /// 打样单编号
        /// </summary>

        public string ProofOrderId { get; set; }

        /// <summary>
        /// 打样单编号
        /// </summary>
        public string Dydbh { get; set; }
        public virtual ProofStyle ProofStyle { get; set; }
        /// <summary>
        /// 申请用户DDid
        /// </summary>
        public string ProofApplyUserDdId { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        [Required]
        public string ProofApplyUserName { get; set; }
        /// <summary>
        /// 指定程序 
        /// </summary>
        public string DesignatedCX { get; set; }

        /// <summary>
        /// 指定工艺
        /// </summary>
        public string DesignatedGY { get; set; }

        /// <summary>
        /// 紧急度
        /// </summary>
        public string Urgency { get; set; }
        /// <summary>
        /// 申请部门名
        /// </summary>
        public string ProofApplyDeptName { get; set; }
        /// <summary>
        /// 钉钉审批流code
        /// </summary>
        public string DdApprovalCode { get; set; }
        /// <summary>
        /// 打样状态 草拟 审批 退回  排单 打样中 完成
        /// </summary>
        public  ProofStatus ProofStatus { get; set; }

        /// <summary>
        /// 状态文本
        /// </summary>
        [NotMapped]
        public string ProofStatusText
        {
            get
            {
                return ProofStatus.ToString();
            }
        }
        [NotMapped]
        public string CreateDateStr
        {
            get
            {

                if (CreateDate != null) return CreateDate.Value.ToShortDateString();
                return "";
            }
        }
        /// <summary>
        /// 打样任务
        /// </summary>
        public virtual List<ProofTask> ProofTasks { get; set; }

        /// <summary>
        /// 打样记录
        /// </summary>
        public virtual List<ProofLog> ProofLogs { get; set; } = new List<ProofLog>();

        /// <summary>
        /// 要求完成日期
        /// </summary>
        public DateTime? RequiredDate { get; set; }
        /// <summary>
        /// 打样数量
        /// </summary>
        public int ProofNum { get; set; }
        /// <summary>
        /// 接收日期
        /// </summary>
        public DateTime? ReceivedDate { get; set; }
        /// <summary>
        /// 完成日期
        /// </summary>
        public DateTime? FinshDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public void AddLog(string name,string msg)
        {
            ProofLogs.Add(new ProofLog
            {
                Name = name,
                Msg = msg,
                LogDate = DateTime.Now
            });
        }
    }
}
