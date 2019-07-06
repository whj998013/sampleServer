using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;

namespace SG.Model.Sys
{
    public class Role : BaseModel, IRole
    {
        public int Id { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public string Note { get; set; }
        public Prange PV { get; set; } 
        public Prange PM { get; set; }

    }

    public enum Prange
    {
        仅个人 = 0,
        当前部门 = 1,
        当前及下级部门 = 2,
        全部 = 3
    }
}
