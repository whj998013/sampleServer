using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DdApi.Approve
{
    public class ApproveItems:List<ApproveItem>
    {
        public string ApproveName { get; set; }
        public string ObjId { get; set; }

    }
}
