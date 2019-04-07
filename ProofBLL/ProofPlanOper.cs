using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
using SG.Model.Proof;
using SampleDataOper;
using System.Data.Entity;
namespace ProofBLL
{
    public class ProofPlanOper
    {
        SunginDataContext sdc = new SunginDataContext();
        User _user;
        public ProofPlanOper(User u)
        {
            _user = u;
        }
        public bool DoProofPlan(string orderId, string workerName, string processName)
        {
            var process = sdc.Processlist.SingleOrDefault(p => p.ProcessName == processName);
            var worker = sdc.Workers.Include(t => t.User).SingleOrDefault(p => p.UserName == workerName);
            var order = sdc.ProofOrders.Include(t => t.ProofStyle).SingleOrDefault(p => p.ProofOrderId == orderId);
            if (process == null || worker == null || order == null) return false;
            var pt = sdc.ProofTasks.Where(p => p.Order.Id == order.Id && p.Process.Id == process.Id).SingleOrDefault();
            if (pt == null)
            {

                pt = new ProofTask();
                pt.UserName = workerName;
                pt.Worker = worker;
                pt.Process = process;
                pt.Order = order;
                pt.BeginDate = DateTime.Now;
                pt.NeedFinshDate = order.RequiredDate;
                pt.SetCreateUser(_user.UserName);
                sdc.ProofTasks.Add(pt);
                if (order.ReceivedDate == null) order.ReceivedDate = DateTime.Now;
                order.ProofStatus = ProofStatus.打样中;
                order.ProofTasks.Add(pt);

            }
            else
            {
                pt.UserName = workerName;
                pt.Worker = worker;
                pt.SetEditUser(_user.UserName);
            }


            return true;
        }

        public void SaveChanges()
        {
            sdc.SaveChanges();
        }
    }
}
