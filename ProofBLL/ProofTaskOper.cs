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

                    pt = new ProofTask();
                    pt.UserName = workerName;
                    pt.Worker = worker;
                    pt.Process = process;
                    pt.Order = order;
                    pt.BeginDate = DateTime.Now;
                    pt.NeedFinshDate = needFinshDate;
                    pt.Num = order.ProofNum;
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
                 //ptlist = sdc.ProofTasks.Include(t=>t.Process).Include(t=>t.Order).Include(t=>t.Order.ProofStyle).Include(t=>t.Order.ProofStyle.ProofFiles).Include(t=>t.Order.ProofStyle.ProofType).Where(p => p.Worker.Id == worker.Id).ToList();
              ptlist = sdc.ProofTasks.Where(p => p.Worker.Id == worker.Id).Select(p=>new {p.Id, p.UserName,p.Order.ProofNum,p.BeginDate,p.NeedFinshDate,p.Process.ProcessName,p.Order.ProofOrderId,p.Order.ProofStyle.ProofStyleNo,p.Order.Urgency,p.Order.ProofStyle.ProofType.TypeName}).ToList();

            }


            return ptlist;
        }

        public void SaveChanges()
        {
            sdc.SaveChanges();
        }
    }
}
