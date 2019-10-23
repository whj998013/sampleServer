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
        readonly SunginDataContext sdc = new SunginDataContext();
        readonly PvmDeptOper pdo = PvmDeptOper.GetPvmDeptOper();
        public PvmOper(User u)
        {
            _user = u;
        }
        /// <summary>
        /// 返回权限点操作部门列表
        /// </summary>
        /// <param name="key"></param>
        public List<DeptNode> GetDeptsByPermissionKey(string key, PvmType pt)
        {
            var pr = GetPvm(key,pt );
            return GetDeptListByPrange(pr);
        }
        /// <summary>
        /// 返回权限点操作权限
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Prange GetPvm(string key,PvmType pt)
        {
            var roles = sdc.UserRolePermissions.Where(p => p.Key == key).Select(p => p.RoleId).ToList();
            Prange pvm = Prange.仅个人;
            sdc.UserRoles.Where(p => p.DdId == _user.DdId).ToList().ForEach(p =>
            {
                if (roles.Contains(p.RoleId))
                {
                    var role = sdc.Roles.Single(r => r.RoleId == p.RoleId);
                    if (pt == PvmType.PM) pvm = role.PM > pvm ? role.PM : pvm;
                    else pvm = role.PV > pvm ? role.PV : pvm;
                }
            });
            return pvm;
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
            }
            else if (pvm == Prange.当前及下级部门 || pvm == Prange.全部)
            {
                ls.AddRange(pdo.GetDeptNameList(deptIdList));
            }
            return ls;
        }

        // 根所用户Id返回用户可操作的部门列表
        public List<DeptNode> GetDeptList(PvmType pt)
        {
            var pvm = GetPvm(pt);
            return GetDeptListByPrange(pvm);
        }

        /// <summary>
        /// 根据用户权限返回当前用户可操作的部门列表
        /// </summary>
        /// <param name="pvm"></param>
        /// <returns></returns>
        public List<DeptNode> GetDeptListByPrange(Prange pvm)
        {
            List<DeptNode> depts = new List<DeptNode>();

            List<long> deptIdlist = new List<long>();
            string deptstr = _user.DeptId.Replace('[', ' ').Replace(']', ' ');
            deptstr.Split(',').ToList().ForEach(did =>
            {
                deptIdlist.Add(long.Parse(did));
            });



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

    public static class DeptNodeHelp
    {
        public static List<string> ToDeptNameList(this List<DeptNode> ld)
        {
            List<string> ls = new List<string>();
            ld.ForEach(p =>
            {
                ls.AddRange(p.GetNameList());
            });
           
            return ls;
        }

        public static List<long> ToDeptIdList(this List<DeptNode> ld)
        {
            List<long> ls = new List<long>();
            ld.ForEach(p =>
            {
                ls.AddRange(p.GetIdList());
            });

            return ls;
        }
    }

}
