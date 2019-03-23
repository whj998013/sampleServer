using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
using SampleDataOper;
namespace SysBLL
{
    public class DeptOper
    {
        public List<Dept> GetDepts()
        {
            return DataQuery.GetRecords<Dept>().ToList();
           
        }

        public void SyncDepts(List<Dept> depts)
        {
            using (SunginDataContext sc=new SunginDataContext())
            {
                var deptList = sc.Depts.ToList();
                deptList.ForEach(p => p.IsDelete = true);
                depts.ForEach(p =>
                {
                    var d = deptList.SingleOrDefault(t => t.DeptID == p.DeptID);
                    if (d == null) sc.Depts.Add(p);
                    else
                    {
                        d.DeptName = p.DeptName;
                        d.ParentDeptId = p.ParentDeptId;
                        d.DeptAdminDdId = p.DeptAdminDdId;
                        d.IsDelete = false;
                     }

                });
                sc.SaveChanges();
            };

        }

        public string GetDeptName(long deptId)
        {

            return null;

        }

    }
}
