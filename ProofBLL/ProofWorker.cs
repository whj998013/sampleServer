using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataOper;

using System.Data.Entity;
namespace ProofBLL
{
    public class ProofWorker
    {
        SunginDataContext sdc = new SunginDataContext();
        public ProofWorker()
        {

        }
        public object GetWorkList(int id)
        {
            var workers = sdc.Workers.Include(t => t.Job).Include(t => t.Role).Where(p => p.Job.Id == id).ToList();
            List<object> objs = new List<object>();
            workers.ForEach(p =>
            {
                int InCompleteNum = sdc.ProofTasks.Count(t => t.FinshDate == null && t.Worker.Id == p.Id);
                DateTime dt = DateTime.Now.AddDays(-7);
                int CompleteNum7Day = sdc.ProofTasks.Count(t => t.FinshDate != null && t.Worker.Id == p.Id&&t.FinshDate>=dt);
                objs.Add(new { p.UserName, p.Avatar, p.Point, InCompleteNum, CompleteNum7Day });
            });

            return objs;
           

        }
    }
}
