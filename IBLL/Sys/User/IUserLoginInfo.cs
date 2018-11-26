using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interface.Sys
{
   public interface IUserLoginInfo
    {
        string DdId { get; set; }
        string UserName { get; set; }
        DateTime? LoginOverTime { get; set; }
        string LoginStr { get; set; }
        string PassWord { get; set; }
        string Ticket { get; set; }
        string Account { get; set; }
    }
}
