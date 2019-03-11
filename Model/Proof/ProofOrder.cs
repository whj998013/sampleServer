﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Proof
{
    /// <summary>
    /// 打样申请单
    /// </summary>
   public class ProofOrder:BaseModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 打样单编号
        /// </summary>
        public string ProofOrderId { get; set; }

        /// <summary>
        /// 打样款式ID
        /// </summary>
        public ProofStyle ProofStyle { get; set; }
        /// <summary>
        /// 申请用户DDid
        /// </summary>
        public string ProofApplyUserDdId { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string ProofApplyUserName { get; set; }
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
        public string ProofStatus { get; set; }
        /// <summary>
        /// 要求完成日期
        /// </summary>
        public DateTime? RequiredDate { get; set; }
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
    }
}