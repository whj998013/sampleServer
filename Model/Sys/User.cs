using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.Sys;

namespace Model.Sys
{
    public class User : BaseModel, IUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string DepartName { get; set; }
        public string DdId { get; set; }
        public string Avatar { get; set; }
        public string LoginStr { get; set; }
        public UserRoleU Role { get; set; }
        public DateTime? LoginOverTime { get; set; }
        [NotMapped]
        public string Ticket { get; set; }
    }


}
