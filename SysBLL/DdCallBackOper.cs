using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProofBLL;
using SG.Model.Proof;
using SG.Model.Sys;
using SunginData;
using SG.DdApi.Approve;
using SG.DdApi;
using System.Web;
using SG.Interface.Sys;
using ProofBLL.Bll;

namespace SysBLL
{
    public class DdCallBackSysOper
    {
        public delegate void delegateDoCallBack(dynamic obj);

        public event delegateDoCallBack HaveDdCallBack;
        
        private static DdCallBackSysOper _instance = null;

        public List<string> EventTypes { get; set; } = new List<string>();
        private DdCallBackSysOper()
        {

        }
        public void AddCallBack(SG.DdApi.Interface.DdApprove approve)
        {
            HaveDdCallBack += approve.DoCallBack;
        }
        public static DdCallBackSysOper GetOper()
        {
            if (_instance == null) _instance = new DdCallBackSysOper();
            return _instance;
        }

        public void DdCallBack(dynamic obj)
        {
            string et = (string)obj.EventType;

            if (EventTypes.Contains(et))
            {
                HaveDdCallBack(obj);
            }

        }
      

    }
}
