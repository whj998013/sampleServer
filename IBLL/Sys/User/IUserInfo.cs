using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interface.Sys
{
  public  interface IUserInfo:INameId
    {
        string DepartName { get; set; }
        string Avatar { get; set; }
    }
}
