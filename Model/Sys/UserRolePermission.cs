using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
namespace SG.Model.Sys
{
    public class UserRolePermission : BaseModel, IUserRolePermission
    {
        public int Id { get; set; }
        /// <summary>
        /// PermissionKey
        /// </summary>
        public string Key { get; set; }
        public long RoleId { get; set; }
        public string DdId { get; set; }
    }
}
