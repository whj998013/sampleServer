using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
using SG.Interface;

namespace SG.Model.Sys
{
    public class Dept:BaseModel,IDept,ICovertToSon
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public long DeptID { get; set; }
        public long ParentDeptId { get; set; }
        public string DeptAdminDdId { get; set; }
        public bool IsProofDept { get; set; } = false;
        
    }
}
