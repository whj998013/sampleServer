using SG.Model.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunginData.Migrations
{
    public class BuildHelper
    {
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="context"></param>
        public static void BuildData(SunginData.SunginDataContext context)
        {

            int i = 1;
            context.Roles.AddOrUpdate(m => m.RoleId, new Role
            {
                RoleId = 0,
                RoleName = "默认用户"
            });

            DataDefaultList.GetUnitList().ForEach(p =>
            {
                p.Id = i++;
                context.Units.AddOrUpdate(m => m.Id, p);
            });

            DataDefaultList.GetCodeList().ForEach(p =>
            {
                p.Id = i++;
                context.Codes.AddOrUpdate(m => m.Id, p);
            });

            i = 1;
            DataDefaultList.GetMaterialList().ForEach(p =>
            {
                p.Id = i++;
                context.Materials.AddOrUpdate(m => m.Id, p);
            });

            i = 1;
            DataDefaultList.GetPermissionsList().ForEach(p =>
            {
                p.Id = i++;
                context.Permissions.AddOrUpdate(m => m.Key, p);
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
                if (context.WorkerDepts.SingleOrDefault(bm => bm.DeptName == p.DeptName) == null)
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
            DataDefaultList.GetPurposes().ForEach(p =>
            {
                if (context.Purposes.SingleOrDefault(pur => pur.Name == p.Name) == null)
                {
                    context.Purposes.Add(p);
                }
            });
            context.SaveChanges();
        }

        public static void InitData(SunginDataContext context)
        {
            var f = context.LendRecords.FirstOrDefault();
            if (f != null && f.LendDay == 0)
            {
                context.LendRecords.ToList().ForEach(p =>
                {
                    p.LendDay = 7;
                    p.LendPurpose = "其它";
                });
                context.SaveChanges();
            }
        }
        public static void ReNameDatatabel(SunginData.SunginDataContext context)
        {
            try
            {
                //重命名表
                var drop1 = "EXEC sp_rename  'LendOutViews_bak','LendOutViews'";
                context.Database.ExecuteSqlCommand(drop1);
            }
            catch
            { 
            }
        }

        /// <summary>
        ///重建视图
        /// </summary>
        /// <param name="context"></param>

        public static void ReBuildLendOutViews(SunginData.SunginDataContext context)
        {
            //删除表或视图


            try
            {
                //重命名表
                var drop1 = "EXEC sp_rename  'LendOutViews','LendOutViews_bak'";
                context.Database.ExecuteSqlCommand(drop1);
            }
            catch
            {
                try
                {
                    var drop = "Drop View LendOutViews";
                    context.Database.ExecuteSqlCommand(drop);
                }
                catch { };
            };

            //建立视图
            var createView = @"CREATE VIEW [dbo].[LendOutViews] AS 
                SELECT   dbo.LendRecords.Id, dbo.LendRecords.StyleId, dbo.LendRecords.DdId, dbo.LendRecords.UserName, 
                dbo.LendRecords.UserDept, dbo.LendRecords.LendOutDate, dbo.LendRecords.LendOutNo,dbo.LendRecords.CreateDate,
                dbo.LendRecords.ReturnDate, dbo.LendRecords.ReturnNo, dbo.LendRecords.State,  dbo.LendRecords.LendDay,  dbo.LendRecords.LendPurpose, 
                dbo.SampleBaseInfoes.CreateUser AS InUserName, dbo.SampleBaseInfoes.DeptName AS InUserDept, 
                dbo.SampleBaseInfoes.DdId AS InDdId, dbo.LendRecords.IsDelete,dbo.SampleBaseInfoes.StyleNo,
                dbo.SampleBaseInfoes.Gauge,dbo.SampleBaseInfoes.Color,dbo.SampleBaseInfoes.Size,dbo.SampleBaseInfoes.Kinds,dbo.SampleBaseInfoes.Material,
                    (SELECT   TOP (1) FileName
                     FROM      dbo.StyleFiles
                     WHERE   (StyleId = dbo.LendRecords.StyleId) AND (FileType = 0)) AS StylePic
                FROM      dbo.LendRecords INNER JOIN
                dbo.SampleBaseInfoes ON dbo.LendRecords.StyleId = dbo.SampleBaseInfoes.StyleId
                ";
            context.Database.ExecuteSqlCommand(createView);
        }
    }
}
