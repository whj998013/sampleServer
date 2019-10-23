using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
using SunginData;
using EntityFramework.Extensions;
using System.Data.Entity;
namespace SysBLL
{
    public class WorkerOper
    {
        readonly SunginDataContext sdc = new SunginDataContext();
        public void SyncWorker()
        {

            SyncWorkerForRole("工艺员");
            SyncWorkerForRole("程序员");
        }
        void SyncWorkerForRole(string roleName)
        {
            var role = sdc.Roles.FirstOrDefault(p => p.RoleName == roleName);
            var ur = sdc.UserRoles.Where(p => p.RoleId == role.RoleId).ToList();
            var workerRole = sdc.FactryRolesWorker.Include(t => t.Job).Include(t => t.Worker).Where(p => p.Role.RoleId == role.RoleId).ToList();
            var workers = sdc.Workers.Include(t => t.Job).Include(t => t.User).ToList();
            workerRole.ForEach(t => t.IsDelete = true);
            ur.ForEach(p =>
            {
                var job = sdc.Jobs.SingleOrDefault(j => j.JobName == roleName);
                var user = sdc.Users.SingleOrDefault(u => u.DdId == p.DdId);
                var wr = workerRole.SingleOrDefault(w => w.WorkName == p.UserName);
                var worker = workers.SingleOrDefault(w => w.UserName == p.UserName);
                if (worker == null)
                {
                    worker = new Worker()
                    {
                        UserName = p.UserName,
                        User = sdc.Users.SingleOrDefault(u => u.DdId == p.DdId),
                        DeptName="样品部",
                        Point=3
                    };
                    sdc.Workers.Add(worker);
                 }

                if (wr == null)
                {

                    FactryRoleWorker wk = new FactryRoleWorker
                    {
                       JobName=job.JobName,
                       WorkName=worker.UserName,
                       Worker=worker,
                       Role=role,
                       Job=job,
                    };
                    sdc.FactryRolesWorker.Add(wk);
                }
                else
                {
                    wr.IsDelete = false;
                }


            });
            sdc.SaveChanges();

        }

    }
}
