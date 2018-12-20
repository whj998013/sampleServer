using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;

namespace SG.Model.Sys
{
    public class Dept:BaseModel,IDept
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public long DeptID { get; set; }
        public long ParentDeptId { get; set; }
        public string DeptAdminDdId { get; set; }
        
    }
}
