using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
namespace SG.Model.Sys
{
    public class UserRole : BaseModel, IUserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
