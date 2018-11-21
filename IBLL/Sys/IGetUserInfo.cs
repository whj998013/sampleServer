using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interface.Sys
{
    public interface IGetUserInfo
    {
        IUser GetUserInfo(string DdId);
    }
}
