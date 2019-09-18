namespace SunginData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SG.Interface.Sys;
    using SG.Model.Sample;
    using SG.Model.Sys;

    internal sealed class Configuration : DbMigrationsConfiguration<SunginData.SunginDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SampleDataOper.SampleContext";
        }

        protected override void Seed(SunginData.SunginDataContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            int i = 1;
            
            context.Roles.AddOrUpdate(m=>m.RoleId, new Role
            {
                RoleId = 0,
                RoleName ="Ä¬ÈÏÓÃ»§"
             });

            DataDefaultList.GetUnitList().ForEach(p =>
            {
                p.Id = i++;
                context.Units.AddOrUpdate(m => m.Id, p);
            });

            DataDefaultList.GetCodeList().ForEach(p =>
            {
                p.Id = i++;
                context.Codes.AddOrUpdate(m => m.Id,p);
            });

            i = 1;
            DataDefaultList.GetMaterialList().ForEach(p =>
            {
                p.Id = i++;
                context.Materials.AddOrUpdate(m => m.Id,p);
            });
          
            i = 1;
            DataDefaultList.GetPermissionsList().ForEach(p =>
            {
                p.Id = i++;
                context.Permissions.AddOrUpdate(m => m.Key,p );
            });

            DataDefaultList.GetKmList().ForEach(p =>
            {
                if (context.KMs.SingleOrDefault(t => t.KeyName == p.KeyName) == null)
                {
                    context.KMs.Add(p);
                }
              });

            DataDefaultList.GetProofTypeList().ForEach(p =>
            {
                if (context.ProofTypes.SingleOrDefault(t => t.TypeName == p.TypeName) == null)
                {
                    context.ProofTypes.Add(p);
                }
            });
            DataDefaultList.GetProcessList().ForEach(p =>
            {
                if (context.Processlist.SingleOrDefault(t => t.ProcessName == p.ProcessName) == null)
                {
                    context.Processlist.Add(p);
                }
            });

            DataDefaultList.GetWorkerDepts().ForEach(p =>
            {
                if(context.WorkerDepts.SingleOrDefault(bm=>bm.DeptName==p.DeptName)==null)
                {
                    context.WorkerDepts.Add(p);
                }

            });

            DataDefaultList.GetJobs().ForEach(p =>
            {
                if (context.Jobs.SingleOrDefault(job => job.JobName == p.JobName) == null)
                {
                    context.Jobs.Add(p);
                }
            });
            context.SaveChanges();

        }

    }
}
