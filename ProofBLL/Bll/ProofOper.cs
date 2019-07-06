using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SG.Model.Sys;
using SunginData;
using System.Data.Entity;

namespace ProofBLL
{
    public class ProofOrderOper
    {
        private User _user;
        public SunginDataContext Sdc { get; set; } = new SunginDataContext();
        public ProofOrderOper(User user)
        {
            _user = user;
        }

        public List<ProofOrder> GetUserProofOrderList()
        {

            List<ProofOrder> poList = new List<ProofOrder>();
            poList = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofApplyUserDdId == _user.DdId && p.ProofStatus != ProofStatus.完成 && !p.IsDelete).OrderByDescending(p => p.CreateDate).ToList();
            poList.ForEach(p =>
            {
                p.ProofStyle.ProofFiles = p.ProofStyle.ProofFiles.Where(f => !f.IsDelete).ToList();

            });
            return poList;
        }

        public object GetFinshPlanList()
        {
            List<ProofOrder> poList = new List<ProofOrder>();
            poList = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => (p.ProofStatus == ProofStatus.完成) && !p.IsDelete).OrderBy(p => p.ProofStatus).ThenByDescending(p => p.CreateDate).ToList();
            return poList;
        }
 
        /// <summary>
        /// 完成打样，并提交审批
        /// </summary>
        /// <returns></returns>
        public ProofOrder FinshProof(string proofOrderid)
        {
            ProofOrder po = Sdc.ProofOrders.SingleOrDefault(p => p.ProofOrderId == proofOrderid);
            if (po == null) return null;
            po.ProofTasks.ForEach(p =>
            {
                p.FinshDate = DateTime.Now;
                p.Stats = SG.Model.Stats.终止;
                p.OperRemark = "订单完成，主动终止任务";

            });
            po.ProofStatus = ProofStatus.交样;
            return po;

        }

        public List<ProofOrder> GetUserFineshProofOrderList()
        {

            List<ProofOrder> poList = new List<ProofOrder>();
            poList = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofApplyUserDdId == _user.DdId && p.ProofStatus == ProofStatus.完成 && !p.IsDelete).OrderByDescending(p => p.CreateDate).ToList();
            poList.ForEach(p =>
            {
                p.ProofStyle.ProofFiles = p.ProofStyle.ProofFiles.Where(f => !f.IsDelete).ToList();

            });
            return poList;
        }

        public List<ProofOrder> GetPlanProofList()
        {
            List<ProofOrder> poList = new List<ProofOrder>();
            poList = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => (p.ProofStatus == ProofStatus.排单 || p.ProofStatus == ProofStatus.打样中 || p.ProofStatus == ProofStatus.交样) && !p.IsDelete).OrderBy(p => p.ProofStatus).ThenByDescending(p => p.CreateDate).ToList();
            return poList;
        }

        public ProofOrder GetProof(string proofOrderId)
        {
          
            ProofOrder po = Sdc.ProofOrders.Include(t => t.ProofTasks).Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofOrderId == proofOrderId).SingleOrDefault();
            if (po != null)
            {
                Sdc.Entry(po.ProofStyle).Collection(t => t.ProofFiles).Query().Where(t => !t.IsDelete).Load();

                Sdc.Entry(po).Collection(t => t.ProofTasks).Query().Include(t => t.Process).Include(t=>t.Worker).Load();
                po.ProofTasks = po.ProofTasks.Where(p => !p.IsDelete).ToList();
            }

            return po;
        }
        public bool DeleteProof(string proofOrderId)
        {
            ProofOrder po = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofOrderId == proofOrderId).SingleOrDefault();
            po.Delete(_user.UserName);
            po.ProofStyle.Delete(_user.UserName);
            po.ProofStyle.ProofFiles.ForEach(p =>
            {
                p.Delete(_user.UserName);
            });
           // Sdc.SaveChanges();

            return true;
        }
        public void SetApprove(ProofOrder po, string ddApprovalCode)
        {
            po.DdApprovalCode = ddApprovalCode;
            po.ProofStatus = ProofStatus.审批;
          //  Sdc.SaveChanges();
        }

        public void SetFinshApprove(ProofOrder po, string ddApprovalCode)
        {
            po.DdFinshApprovalCode = ddApprovalCode;
            po.ProofStatus = ProofStatus.交样;
           // Sdc.SaveChanges();
        }
        public void SaveChange()
        {
            Sdc.SaveChanges();
        }

    }
}
