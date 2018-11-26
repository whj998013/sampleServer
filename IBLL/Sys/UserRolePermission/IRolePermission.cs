using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interface.Sys
{
   public interface IRolePermission
    {
        string Key { get; set; }
        long RoleId { get; set; }
    }
}
