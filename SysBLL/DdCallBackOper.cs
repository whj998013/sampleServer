using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProofBLL;
using SG.Model.Proof;
using SG.Model.Sys;
using SampleDataOper;
using SG.DdApi.Approve;
using SG.DdApi;
using System.Web;

namespace SysBLL
{
    public class DdCallBackSysOper
    {
        private static DdCallBackSysOper _instance = null;
        string ProofProcessCode, FinshProofProcessCode;
        public string SysPath { get; set; }
        private DdCallBackSysOper()
        {

            ProofProcessCode = ConfigurationManager.AppSettings["ProofProcessCode"];
            FinshProofProcessCode = ConfigurationManager.AppSettings["FinshProofProcessCode"];
         

        }
        public static DdCallBackSysOper GetOper()
        {
            if (_instance == null) _instance = new DdCallBackSysOper();
            return _instance;
        }

        public void DdCallBack(dynamic obj)
        {
            if (obj.EventType == "bpms_task_change" || obj.EventType == "bpms_instance_change")
            {

                //钉钉样衣申请回调
                if (obj.processCode == ProofProcessCode && obj.type == "finish")
                {

                    ProofOrderApprove Poa = new ProofOrderApprove();
                    string pid = obj.processInstanceId;
                    if (obj.result == "agree")
                    {

                        //同意
                        Poa.AgreeApprove(pid);
                    }
                    else
                    {
                        //拒绝
                        Poa.RefuseApprove(pid);
                    }

                }
                //钉钉样衣交样回调

                if (obj.processCode == FinshProofProcessCode && obj.type == "finish")
                {

                    ProofOrderFinsh Pof = new ProofOrderFinsh(DdOperator.GetDdApi());
                    Pof.SysPath = SysPath;
                    string pid = obj.processInstanceId;
                    if (obj.result == "agree")
                    {

                        //同意
                        Pof.AgreeFinsh(pid);
                    }
                    else
                    {
                        //拒绝
                        Pof.RefuseFinsh(pid);
                    }

                }
            }

        }
    }
}
