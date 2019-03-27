using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.DdApi.Approve;
using SG.Model.Proof;
using SampleDataOper;
using System.Data.Entity;
namespace ProofBLL
{
    public class ProofOrderApprove
    {
        private SunginDataContext sdc = new SunginDataContext();
        public ProofOrderApprove()
        {
          
        }
        public static List<ApproveItem> ToApprove(ProofOrder order)
        {
            List<ApproveItem> la = new List<ApproveItem>() {
                new ApproveItem
                {
                    Name="申请人",
                    Value=order.ProofApplyUserName,
                },
                 new ApproveItem
                {
                    Name="编号",
                    Value=order.ProofOrderId,
                },
                  new ApproveItem
                {
                    Name="客户",
                    Value=order.ProofStyle.ClentName,
                },
                   new ApproveItem
                {
                    Name="款号",
                    Value=order.ProofStyle.ProofStyleNo,
                }, new ApproveItem
                {
                    Name="打样类别",
                    Value=order.ProofStyle.ProofTypeText,
                }, new ApproveItem
                {
                    Name="件数",
                    Value=order.ProofNum.ToString(),
                },new ApproveItem
                {
                    Name="完成日期",
                    Value=order.RequiredDate.ToString(),
                },
            };

            return la;
        }

        public  void AgreeApprove(string DdApprovalCode)
        {
            var order = GetProofByDdApprovalCode(DdApprovalCode);
            order.ProofStatus = ProofStatus.排单;
            sdc.SaveChanges();
          

        }
        public  void RefuseApprove(string DdApprovalCode)
        {
            var order = GetProofByDdApprovalCode(DdApprovalCode);
            order.ProofStatus = ProofStatus.退回;
            sdc.SaveChanges();
        }
        public ProofOrder GetProofByDdApprovalCode(string DdApprovalCode)
        {
            ProofOrder po = sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.DdApprovalCode == DdApprovalCode).SingleOrDefault();
            return po;
        }
    }
}
