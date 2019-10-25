﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;

using System.Data.Entity;
namespace ProofBLL
{
    public class ProofWorker
    {
        readonly SunginDataContext sdc = new SunginDataContext();
        public ProofWorker()
        {

        }
        public object GetWorkList(int id)
        {
            var workers = sdc.FactryRolesWorker.Include(t => t.Worker).Where(p => p.Job.Id == id).ToList();
            //var workers2 = sdc.Workers.Include(t => t.Job).Include(t => t.Role).Where(p => p.Job.Id == id).ToList();
            List<object> objs = new List<object>();
            workers.ForEach(p =>
            {
                int InCompleteNum = sdc.ProofTasks.Count(t => t.FinshDate == null && t.Worker.Id == p.Worker.Id);
                DateTime dt = DateTime.Now.AddDays(-7);
                int CompleteNum7Day = sdc.ProofTasks.Count(t => t.FinshDate != null && t.Worker.Id == p.Worker.Id && t.FinshDate >= dt);
                objs.Add(new { p.Worker.Id, p.Worker.UserName, p.Worker.Avatar, p.Worker.Point, InCompleteNum, CompleteNum7Day });
            });

            return objs;

        }
        public object GetProcessList()
        {
            var processList = sdc.Processlist.ToList();
            return processList;
        }

        public object GetProofDeptList()
        {
            List<object> objs = new List<object>();
            var depts = sdc.Depts.Where(p => p.IsProofDept).ToList();
            depts.ForEach(p =>
            {
                string adminId = p.DeptAdminDdId.Split(',')[0];
                var user = sdc.Users.SingleOrDefault(t => t.DdId == adminId);
                if (user != null)
                {
                    objs.Add(new { p.DeptID, p.DeptName, user.UserName, user.DdId });
                }

            });

            return objs;
        }
    }
}
