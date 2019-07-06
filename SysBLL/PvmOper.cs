using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
using SunginData;
namespace SysBLL
{
    public enum PvmType
    {
        PV = 0,
        PM = 1
    }

    public class PvmOper
    {
        User _user;
        SunginDataContext sdc = new SunginDataContext();
        PvmDeptOper pdo = PvmDeptOper.GetPvmDeptOper();
        public PvmOper(User u)
        {
            _user = u;
        }

        public Prange GetPvm(PvmType pt)
        {
            Prange pvm = Prange.仅个人;
            sdc.UserRoles.Where(p => p.DdId == _user.DdId).ToList().ForEach(p =>
             {
                 var role = sdc.Roles.Single(r => r.RoleId == p.RoleId);
                 if (pt == PvmType.PM) pvm = role.PM > pvm ? role.PM : pvm;
                 else pvm = role.PV > pvm ? role.PV : pvm;
             });
            return pvm;
        }

        public List<string> GetDeptNameList(List<long> deptIdList, PvmType pt)
        {
            Prange pvm = GetPvm(pt);
            List<string> ls = new List<string>();
            if (pvm == Prange.当前部门)
            {
                deptIdList.ForEach(p =>
                {
                    ls.Add(pdo.GetDeptById(p).DeptName);
                });
            }else if (pvm == Prange.当前及下级部门||pvm==Prange.全部)
            {
                ls.AddRange(pdo.GetDeptNameList(deptIdList));
            }

            return ls;
        }

        // 根所用户Id返回用户显示权限
        public List<DeptNode> GetDeptList(PvmType pt)
        {

            List<DeptNode> depts = new List<DeptNode>();

            List<long> deptIdlist = new List<long>();
            string deptstr = _user.DeptId.Replace('[', ' ').Replace(']', ' ');
            deptstr.Split(',').ToList().ForEach(did =>
            {
                deptIdlist.Add(long.Parse(did));
            });

            var pvm = GetPvm(pt);
            if (pvm == Prange.当前部门)
            {

                deptIdlist.ForEach(did =>
                {
                    var dept = pdo.Depts.SingleOrDefault(p => p.DeptID == did);
                    if (dept != null)
                    {
                        depts.Add(dept.Clone());
                    }
                });

            }
            else if (pvm == Prange.当前及下级部门)
            {
                depts.AddRange(pdo.GetDeptList(deptIdlist));
            }
            else if (pvm == Prange.全部)
            {
                depts = pdo.Depts.Where(p => p.DeptID == 1).ToList();
            }

            return depts;

        }

    }
}
