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
            poList = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofApplyUserDdId == _user.DdId).ToList();
            return poList;
        }

        public ProofOrder GetProof(string proofOrderId)
        {
            ProofOrder po = Sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofOrderId == proofOrderId).SingleOrDefault();
            return po;
        }

        public void SaveChange()
        {
            Sdc.SaveChanges();
        }

    }
}
