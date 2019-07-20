using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interface.Sys
{
   public interface IDept
    {
         string DeptName { get; set; }
         long DeptID { get; set; }
         long ParentDeptId { get; set; }
         bool IsProofDept { get; set; } 
    }
}
