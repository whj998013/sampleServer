using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SampleDataOper;
using SG.Model.Sys;
using System.Data.Entity;
namespace ProofBLL
{
    public class ProofTaskOper
    {
        SunginDataContext sdc = new SunginDataContext();
        User _user;
        public ProofTaskOper(User u)
        {
            _user = u;
        }

        public bool DeleteTask(int Id)
        {
            var t = sdc.ProofTasks.SingleOrDefault(p => p.Id == Id);
            if (t != null)
            {
                t.Delete(_user.UserName);
                return true;
            }
            return false;

        }

        public ProofTask UpDateTask(Task t)
        {
            ProofTask re = sdc.ProofTasks.Include(tp=>tp.Order).SingleOrDefault(p => p.Id == t.Id);
            if (re != null)
            {
                re.UserName = t.WorkerName;
                re.Worker = sdc.Workers.FirstOrDefault(p => p.UserName == t.WorkerName);
                re.Process = sdc.Processlist.FirstOrDefault(p => p.Id == t.ProcessId);
                re.NeedFinshDate = t.NeedFinshDate;
            }
            sdc.SaveChanges();
            return re;

        }
        public ProofTask AddTask(Task t)
        {
            try
            {
                var process = sdc.Processlist.SingleOrDefault(p => p.Id == t.ProcessId);
                var worker = sdc.Workers.FirstOrDefault(p => p.UserName == t.WorkerName);
                var order = sdc.ProofOrders.SingleOrDefault(p => p.ProofOrderId == t.ProofOrderId);
                if (process == null || worker == null || order == null) return null;
                var pt = sdc.ProofTasks.Where(p => p.Order.Id == order.Id && p.Process.Id == process.Id&&p.Worker.Id==worker.Id).SingleOrDefault();
                if (pt == null)
                {
                    pt = new ProofTask
                    {
                        UserName = t.WorkerName,
                        Worker = worker,
                        Process = process,
                        Order = order,
                        BeginDate = DateTime.Now,
                        NeedFinshDate = t.NeedFinshDate,
                        Num = order.ProofNum
                    };
                    pt.SetCreateUser(_user.UserName);
                    sdc.ProofTasks.Add(pt);
                    if (order.ReceivedDate == null) order.ReceivedDate = DateTime.Now;
                    order.ProofStatus = ProofStatus.打样中;
                    order.ProofTasks.Add(pt);
                }
                else
                {
                    order.ProofStatus = ProofStatus.打样中;
                    pt.UserName = t.WorkerName;
                    pt.Worker = worker;
                    pt.Num = order.ProofNum;
                    pt.NeedFinshDate = t.NeedFinshDate;
                    if (pt.IsDelete) pt.UnDelete(_user.UserName);
                    pt.SetEditUser(_user.UserName);
                    
                }
                sdc.SaveChanges();
                return pt;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="workerName"></param>
        /// <param name="processName"></param>
        /// <param name="needFinshDate"></param>
        /// <returns></returns>
        public ProofTask DoProofPlan(string orderId, string workerName, string processName, DateTime? needFinshDate = null)
        {
            try
            {
                var process = sdc.Processlist.SingleOrDefault(p => p.ProcessName == processName);
                var worker = sdc.Workers.Include(t => t.User).FirstOrDefault(p => p.UserName == workerName);
                var order = sdc.ProofOrders.Include(t => t.ProofStyle).SingleOrDefault(p => p.ProofOrderId == orderId);
                if (process == null || worker == null || order == null) return null;
                var pt = sdc.ProofTasks.Where(p => p.Order.Id == order.Id && p.Process.Id == process.Id).SingleOrDefault();
                if (pt == null)
                {

                    pt = new ProofTask
                    {
                        UserName = workerName,
                        Worker = worker,
                        Process = process,
                        Order = order,
                        BeginDate = DateTime.Now,
                        NeedFinshDate = needFinshDate,
                        Num = order.ProofNum
                    };
                    pt.SetCreateUser(_user.UserName);
                    sdc.ProofTasks.Add(pt);
                    if (order.ReceivedDate == null) order.ReceivedDate = DateTime.Now;
                    order.ProofStatus = ProofStatus.打样中;
                    order.ProofTasks.Add(pt);

                }
                else
                {
                    order.ProofStatus = ProofStatus.打样中;
                    pt.UserName = workerName;
                    pt.Worker = worker;
                    pt.Num = order.ProofNum;
                    pt.NeedFinshDate = needFinshDate;
                    pt.SetEditUser(_user.UserName);
                }


                return pt;
            }
            catch
            {
                return null;
            }
        }

        public object GetMyProofTask()
        {
            object ptlist = new object();
            var worker = sdc.Workers.FirstOrDefault(p => p.User.DdId == _user.DdId);
            if (worker != null)
            {
                ptlist = sdc.ProofTasks.Where(p => p.Worker.Id == worker.Id).Select(p => new { p.Id, p.UserName, p.Order.ProofNum, p.BeginDate, p.NeedFinshDate, p.Process.ProcessName, p.Order.ProofOrderId, p.Order.ProofStyle.ProofStyleNo, p.Order.Urgency, p.Order.ProofStyle.ProofType.TypeName }).ToList();

            }
            return ptlist;
        }
        public static ProofTask GetTask(int Id)
        {
            return DataQuery.GetSingle<ProofTask>(p => p.Id == Id);
        }

        public ProofFile AddProofFile(int taskId, string proofId, string fullName, string displayName, string url, string processName)
        {
            var task = sdc.ProofTasks.SingleOrDefault(p => p.Id == taskId);
            var proof = sdc.ProofOrders.Include(t => t.ProofStyle).SingleOrDefault(p => p.ProofOrderId == proofId);
            ProofFile pf = new ProofFile()
            {
                FullName = fullName,
                DisplayName = displayName,
                Url = url,
                ProofStyleId = proof.ProofStyle.ProofStyleId,
            };
            pf.SetCreateUser(_user.UserName);
            if (processName == "工艺") pf.FileType = SG.Interface.Sys.FileType.TechnologyFile;
            else if (processName == "程序") pf.FileType = SG.Interface.Sys.FileType.PlatemakingFile;
            sdc.ProofFiles.Add(pf);
            task.TaskFiles.Add(pf);
            proof.ProofStyle.ProofFiles.Add(pf);
            sdc.SaveChanges();

            return pf;
        }


        public void SaveChanges()
        {
            sdc.SaveChanges();
        }
    }
}
