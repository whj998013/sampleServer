using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using SunginData;
using SG.Model.Sys;
using System.Data.Entity;
using SG.Model;

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
                re.BeginDate = t.BeginDate;
                re.UpTaskNo = t.UpTaskNo;
            }
            sdc.SaveChanges();
            return re;

        }

        public object GetMyFinshProofTask()
        {
            object ptlist = new object();
            var worker = sdc.Workers.FirstOrDefault(p => p.User.DdId == _user.DdId);
            DateTime dt = DateTime.Now.Date;
            if (worker != null)
            {
                ptlist = sdc.ProofTasks.Where(p => p.Worker.Id == worker.Id &&  p.FinshDate != null).Select(p => new { p.Id, p.UserName, p.Order.ProofNum, p.BeginDate, p.NeedFinshDate, p.Process.ProcessName, p.Order.ProofOrderId, p.Order.ProofStyle.ProofStyleNo, p.Order.Urgency, p.Order.ProofStyle.ProofType.TypeName ,p.FinshDate}).ToList();

            }
            return ptlist;

        }

        public ProofTask AddTask(Task t,Stats s)
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
                        BeginDate = t.BeginDate,
                        TaskNo = t.TaskNo,
                        UpTaskNo = t.UpTaskNo,
                        NeedFinshDate = t.NeedFinshDate,
                        Num = order.ProofNum,
                        Stats = s,
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
                    pt.BeginDate = t.BeginDate;
                    pt.UpTaskNo = t.UpTaskNo;
                    pt.Stats = s;
                    if (pt.IsDelete) pt.UnDelete(_user.UserName);
                    pt.SetEditUser(_user.UserName);
                    
                }
                //sdc.SaveChanges();
                return pt;
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// 任务提交
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>

        public string SubmitTask(int taskId)
        {
            ProofTask task = sdc.ProofTasks.Include(t=>t.TaskFiles).SingleOrDefault(t => t.Id == taskId);
            if (task == null) return "无此任务";
            if (task.TaskFiles.Count == 0) return "请上传任务文件";
            task.FinshDate = DateTime.Now;
            task.Stats = Stats.完成;
            return "";
        }

        public string BeginTask(int taskId)
        {
            ProofTask task = sdc.ProofTasks.SingleOrDefault(t => t.Id == taskId);
            if (task == null) return "无此任务";
            task.BeginDate = DateTime.Now.Date;
            return "";
        }

      
        public object GetMyProofTask()
        {
            object ptlist = new object();
            var worker = sdc.Workers.FirstOrDefault(p => p.User.DdId == _user.DdId);
            DateTime dt = DateTime.Now.Date;
            if (worker != null)
            {
                ptlist = sdc.ProofTasks.Where(p => p.Worker.Id == worker.Id&&p.BeginDate<=dt&&p.FinshDate==null).Select(p => new { p.Id, p.UserName, p.Order.ProofNum, p.BeginDate, p.NeedFinshDate, p.Process.ProcessName, p.Order.ProofOrderId, p.Order.ProofStyle.ProofStyleNo, p.Order.Urgency, p.Order.ProofStyle.ProofType.TypeName, p.FinshDate }).ToList();

            }
            return ptlist;
        }
        public static ProofTask GetTask(int Id)
        {
            return DataQuery.GetSingle<ProofTask>(p => p.Id == Id);
        }

        public static List<ProofTask> GetNextTask(int Id)
        {

            SunginDataContext sungindc = new SunginDataContext();
            var no = sungindc.ProofTasks.SingleOrDefault(p => p.Id == Id).TaskNo;
            var tlist = sungindc.ProofTasks.Include(t => t.Process).Where(p => p.UpTaskNo == no).ToList();
            return tlist;
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
