using SG.DdApi.Approve;
using System.Collections.Generic;
using SunginData;
using System.Linq;
using System;
using EntityFramework;
namespace SG.DdApi.Interface
{
    public abstract class DdApprove
    {
        public DdApprove()
        {

        }
        /// <summary>
        /// 进度审批ID
        /// </summary>
        public string ProcessCode { get; set; }
        /// <summary>
        /// 钉钉完成标志 start/change/finish
        /// </summary>
        public string CallBackType { get; set; } = "finish";


        protected string Refuse(string DdApprovalCode)
        {
            using (SunginDataContext sdc = new SunginDataContext())
            {
                var ar = sdc.ApproveRecrods.SingleOrDefault(p => p.ApproveCode == DdApprovalCode);
                if (ar == null) throw new Exception("错误的返回审批ID" + DdApprovalCode);
                ar.FinshDate = DateTime.Now;
                ar.Finshed = true;
                ar.Agree = false;
                sdc.SaveChanges();
                return ar.ObjId;
            }
        }
        protected string Agree(string DdApprovalCode)
        {
            using (SunginDataContext sdc = new SunginDataContext())
            {
                var ar = sdc.ApproveRecrods.SingleOrDefault(p => p.ApproveCode == DdApprovalCode);
                if (ar == null) throw new Exception("错误的返回审批ID" + DdApprovalCode);
                ar.FinshDate = DateTime.Now;
                ar.Finshed = true;
                ar.Agree = true;
                sdc.SaveChanges();
                return ar.ObjId;
            }
        }

        protected abstract void AgreeApprove(string DdApprovalCode);
        
        protected abstract void RefuseApprove(string DdApprovalCode);
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="na"></param>
        /// <param name="items"></param>
        public static string SendApprove(NewApprove na, ApproveItems items)
        {

            using (SunginDataContext sdc = new SunginDataContext())
            {
                string DdApprovalCode = na.SendApprove(items);
                sdc.ApproveRecrods.Add(new Model.Sys.ApproveRecrod()
                {
                    ApproveCode = DdApprovalCode,
                    ApproveName = items.ApproveName,
                    ApproveDate = DateTime.Now,
                    ObjId = items.ObjId,
                });
                sdc.SaveChanges();
                return DdApprovalCode;
            }
        }

        public void DoCallBack(dynamic obj)
        {
            if (obj.processCode == ProcessCode && obj.type == CallBackType)
            {
                string pid = obj.processInstanceId;
                if (obj.result == "agree")
                {
                    AgreeApprove(pid); //同意
                }
                else
                {
                    RefuseApprove(pid);//拒绝
                }
            }

        }
    }
}