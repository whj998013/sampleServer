using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.DdApi.Approve;
using SG.DdApi.Interface;
using SG.Model.Proof;
using SunginData;
using System.Data.Entity;
using ProofData.Bll;

namespace ProofBLL
{
    public class ProofOrderApprove: DdApprove
    {
        private readonly SunginDataContext sdc;
        public ProofOrderApprove(SunginDataContext _sdc)
        {
            sdc = _sdc;

        }
        public ProofOrderApprove()
        {
            sdc = new SunginDataContext();

        }
       
        public static ApproveItems ToApprove(ProofOrder po)
        {
            ApproveItems items = new ApproveItems {
                new ApproveItem
                {
                    Name="申请人",
                    Value=po.ProofApplyUserName,
                },
                 new ApproveItem
                {
                    Name="编号",
                    Value=po.ProofOrderId,
                },
                  new ApproveItem
                {
                    Name="客户",
                    Value=po.ProofStyle.ClentName,
                },new ApproveItem
                {
                    Name="打样部门",
                    Value=po.ProofDept.DeptName,
                },
                   new ApproveItem
                {
                    Name="款号",
                    Value=po.ProofStyle.ProofStyleNo,
                }, new ApproveItem
                {
                    Name="打样类别",
                    Value=po.ProofStyle.ProofTypeText,
                }, new ApproveItem
                {
                    Name="件数",
                    Value=po.ProofNum.ToString(),
                },new ApproveItem
                {
                    Name="完成日期",
                    Value=po.RequiredDate.ToString(),
                },

            };
            items.ApproveName = "打样申请";
            items.ObjId = po.ProofOrderId;
            var pdUser = new ApproveItem
            {
                Name = "派单员",

            };
            var ulist = po.ProofDept.DeptAdminDdId.Split(',').ToList();

#if DEBUG
            ulist = new List<string>() { "manager2606" };
#endif
            pdUser.Value = FastJSON.JSON.ToJSON(ulist);

            items.Add(pdUser);
            return items;
        }

        /// <summary>
        /// 订订审批通过，添加订单到打样系统，并修改状态
        /// </summary>
        /// <param name="DdApprovalCode"></param>
        protected override void AgreeApprove(string DdApprovalCode)
        {
          
            var order = GetProofByDdApprovalCode(DdApprovalCode);
            YdOper yo = new YdOper();
            string dio = yo.AddYd(order);
            if (dio != "")
            {
                order.Dydbh = dio;
                order.ProofStatus = ProofStatus.排单;
                sdc.SaveChanges();
            }

           

        }
        protected override void RefuseApprove(string DdApprovalCode)
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
