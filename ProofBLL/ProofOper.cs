using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SG.Model.Sys;
using SampleDataOper;
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
            poList = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofApplyUserDdId == _user.DdId && p.ProofStatus != ProofStatus.完成 && !p.IsDelete).OrderByDescending(p=>p.CreateDate).ToList();
            poList.ForEach(p =>
            {
                p.ProofStyle.ProofFiles = p.ProofStyle.ProofFiles.Where(f => !f.IsDelete).ToList();

            });

            return poList;
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

        public ProofOrder GetProof(string proofOrderId)
        {
            ProofOrder po = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofOrderId == proofOrderId).SingleOrDefault();
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
            Sdc.SaveChanges();

            return true;
        }
        public void SetApprove(ProofOrder po, string ddApprovalCode)
        {
            po.DdApprovalCode = ddApprovalCode;
            po.ProofStatus = ProofStatus.审批;
            Sdc.SaveChanges();
        }
        public void SaveChange()
        {
            Sdc.SaveChanges();
        }

    }
}
