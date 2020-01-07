using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model
{
    public enum ApplyState
    {
       
        草拟 = 1,
        审批中 = 2,
        通过 = 3,
        已出库 = 4,
        拒绝 = 10,
        仓库审核不通过 =11,
        退回 =12,
        
    }
}
