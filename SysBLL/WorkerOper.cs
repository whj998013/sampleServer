using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
using SampleDataOper;
using EntityFramework.Extensions;
using System.Data.Entity;
namespace SysBLL
{
    public class WorkerOper
    {
        SunginDataContext sdc = new SunginDataContext();
        public void SyncWorker()
        {

            SyncWorkerForRole("工艺员");
            SyncWorkerForRole("程序员");
        }
        void SyncWorkerForRole(string roleName)
        {
            var role = sdc.Roles.FirstOrDefault(p => p.RoleName == roleName);
            var ur = sdc.UserRoles.Where(p => p.RoleId == role.RoleId).ToList();
            var workers = sdc.Workers.Include(t => t.Job).Include(t => t.User).Where(p => p.Role.RoleId == role.RoleId).ToList();
            workers.ForEach(t => t.IsDelete = true);
            ur.ForEach(p =>
            {
                var job = sdc.jobs.SingleOrDefault(j => j.JobName == roleName);
                var user = sdc.Users.SingleOrDefault(u => u.DdId == p.DdId);
                var worker = workers.SingleOrDefault(w => w.UserName == p.UserName);
                if (worker==null)
                {
                  

                    Worker wk = new Worker
                    {
                        UserName = p.UserName,
                        Job = job,
                        Point = 3,
                        Role = role,
                        User = user,
                        DeptName = "样品部",
                        Avatar = user.Avatar,

                    };
                    sdc.Workers.Add(wk);
                }
                else
                {
                    worker.Avatar = user.Avatar;
                    worker.IsDelete = false;

                }


            });
            sdc.SaveChanges();

        }


    }
}
