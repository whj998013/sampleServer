using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SG.Model.Sys;
using SampleDataOper;

namespace ProofBLL
{
    public class ProofOrderOper
    {
        public static List<ProofOrder> GetProofOrderList(User user)
        {

            List<ProofOrder> poList = new List<ProofOrder>();
            using (SampleContext sc = new SampleContext())
            {
                var pftype = sc.ProofTypes.ToList();
                List<string> ls = new List<string>();
                poList = sc.ProofOrders.Include("ProofStyle").Where(p => p.ProofApplyUserDdId == user.DdId).ToList();
                poList.ForEach(p =>
                {
                    ls.Add(p.ProofStyle.ProofStyleId);
                });
                var flist = sc.ProofFiles.Where(p => ls.Contains(p.ProofStyleId)).ToList();
                return poList;

            }

        }


    }
}
