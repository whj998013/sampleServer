using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.Sys;
namespace Model.Sys
{
    public class UserRole :BaseModel, IUserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public long RoleId { get; set; }

    }
}
