using SG.DdApi.Approve;
using System.Collections.Generic;
using SunginData;
using System.Linq;
using System;
using EntityFramework;
using SG.Model.Sys;

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
        /// 钉钉完成标志 start/change/finish/terminate
        /// </summary>
        public List<string> CallBackType { get; set; } = new List<string> { "finish", "terminate" };


        protected ApproveRecrod Refuse(string DdApprovalCode)
        {
            using (SunginDataContext sdc = new SunginDataContext())
            {
                var ar = sdc.ApproveRecrods.SingleOrDefault(p => p.ApproveCode == DdApprovalCode);
                if (ar == null) throw new Exception("错误的返回审批ID" + DdApprovalCode);
                ar.FinshDate = DateTime.Now;
                ar.Finshed = true;
                ar.Agree = false;
                sdc.SaveChanges();
                return ar;
            }
        }
        protected ApproveRecrod Agree(string DdApprovalCode)
        {
            using (SunginDataContext sdc = new SunginDataContext())
            {
                var ar = sdc.ApproveRecrods.SingleOrDefault(p => p.ApproveCode == DdApprovalCode);
                if (ar == null) throw new Exception("错误的返回审批ID" + DdApprovalCode);
                ar.FinshDate = DateTime.Now;
                ar.Finshed = true;
                ar.Agree = true;
                sdc.SaveChanges();
                return ar;
            }
        }
        protected ApproveRecrod GetApproveRecrod(string DdApprovalCode)
        {
            using (SunginDataContext sdc = new SunginDataContext())
            {
                var ar = sdc.ApproveRecrods.SingleOrDefault(p => p.ApproveCode == DdApprovalCode);
                return ar;
            }

        }
        protected abstract void AgreeApprove(string DdApprovalCode);

        protected abstract void RefuseApprove(string DdApprovalCode);

        /// <summary>
        /// 发送请求2
        /// </summary>
        /// <param name="user"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public string SendApprove2(Model.Sys.User user, ApproveItems items)
        {
            NewApprove approve = new NewApprove(DdOperator.GetDdApi())
            {
                User = user,
            };
            approve.ProcessCode = ProcessCode;
            using (SunginDataContext sdc = new SunginDataContext())
            {
                string DdApprovalCode = approve.SendApprove(items);
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

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="na"></param>
        /// <param name="items"></param>
        public static string SendApprove(NewApprove na, ApproveItems items)
        {

            using (SunginDataContext sdc = new SunginDataContext())
            {
                var re = sdc.ApproveRecrods.Count(p => p.ObjId == items.ObjId && p.Finshed == false);
                if (re > 0) return "";
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
            string type = (string)obj.type;
            if (obj.processCode == ProcessCode)
            {
                string pid = obj.processInstanceId;
                if (CallBackType.Contains(type))
                {

                    if (obj.result == "agree")
                    {
                        Agree(pid);
                        AgreeApprove(pid); //同意
                    }
                    else
                    {
                        Refuse(pid);
                        RefuseApprove(pid);//拒绝
                    }
                }
                else if (type == "start")
                {
                    //开始

                }

            }

        }
    }
}