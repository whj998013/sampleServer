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

       
         
    }
}
