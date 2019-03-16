using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SampleDataOper;

namespace ProofBLL
{
   public class ProofTypeOper
    {
        public List<ProofType> GetProofTypeList()
        {
           return DataQuery.GetAllRecords<ProofType>();

        }
    }
}
