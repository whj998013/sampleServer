using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;

namespace Model.Sys
{
    public class Role :BaseModel, IRole
    {
        public int Id { get; set; }
        public long RoleId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
         
    }
}
