using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;

namespace SysBLL.Model
{
    /// <summary>
    /// UserRoleP
    /// </summary>
    public class UrpModel
    {
        public IRole Role { get; set; }
        public List<INameId> UserList { get; set; } = new List<INameId>();
        public List<IRolePermission> PermissionList { get; set; } = new List<IRolePermission>();
        
    }
}
