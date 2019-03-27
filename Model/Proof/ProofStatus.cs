using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Proof
{
    public enum ProofStatus
    {
        退回 = 10,
        草拟 = 0,
        审批 = 1,
        排单 = 2,
        打样中 = 3,
        交样 = 4,
        完成 = 5,

    }
}
