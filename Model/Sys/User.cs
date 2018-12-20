using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;

namespace SG.Model.Sys
{
    public class User : BaseModel, IUser
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// 是否主管
        /// </summary>
        public bool IsLeader { get; set; }
        public string DeptId { get; set; }
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
