using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
namespace SG.Model.Sys
{
   public class UserRolePermission :BaseModel, IUserRolePermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
