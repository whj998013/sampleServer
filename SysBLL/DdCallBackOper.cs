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
namespace SysBLL
{
    public class DdCallBackOper
    {
        string ProofProcessCode;
        public DdCallBackOper()
        {
           
            ProofProcessCode = ConfigurationManager.AppSettings["ProofProcessCode"];
        }
        public void DdCallBack(dynamic obj)
        {
            if (obj.EventType == "bpms_task_change" || obj.EventType == "bpms_instance_change")
            {
              
                if (obj.processCode == ProofProcessCode&&obj.type=="finish")
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
                 
                    //钉钉样衣申请回调
                }
            }

        }
    }
}
