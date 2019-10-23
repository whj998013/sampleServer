using SunginData;
using SG.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface;

namespace SysBLL
{
    public class PvmDeptOper
    {
        private static PvmDeptOper _instance = null;
        public List<DeptNode> Depts { get; set; }

        public static PvmDeptOper GetPvmDeptOper()
        {
            if (_instance == null)
            {
                _instance = new PvmDeptOper();
            }
            return _instance;
        }
        private PvmDeptOper()
        {
            using SunginDataContext sdc = new SunginDataContext();
            Depts = new List<DeptNode>();
            sdc.Depts.Where(p => !p.IsDelete).ToList().ForEach(p =>
              {
                  Depts.Add(p.ToSon<Dept, DeptNode>());
              });
            Depts.ForEach(p =>
            {
                if (p.ParentDeptId != 0)
                {
                    Depts.SingleOrDefault(t => t.DeptID == p.ParentDeptId).Items.Add(p);
                };

            });
        }

        public List<DeptNode> GetDeptList(List<long> idList)
        {
            List<DeptNode> depts = new List<DeptNode>();
            idList.ForEach(p =>
            {
                bool ishave = false;
                idList.ForEach(f =>
                {
                    ishave = ishave || GetDeptById(f).IsHaveDept(p);

                });

                if (!ishave) depts.Add(GetDeptById(p));
            });


            return depts;
        }


        public List<string> GetDeptNameList(List<long> idList)
        {
            List<string> nl = new List<string>();
            idList.ForEach(p =>
            {
                nl.AddRange(GetDeptNameList(p));
            });
            return nl.Distinct().ToList();


        }
        public List<string> GetDeptNameList(long Id)
        {
            return GetDeptById(Id).GetNameList();
        }

        public DeptNode GetDeptById(long Id)
        {
            return Depts.SingleOrDefault(p => p.DeptID == Id);
        }

        public DeptNode GetDeptByName(string name)
        {
            return Depts.SingleOrDefault(p => p.DeptName == name);
        }

    }

    public class DeptNode : Dept
    {
        public List<DeptNode> Items { get; set; } = new List<DeptNode>();
        public bool IsHaveDept(long deptId)
        {
            bool have = Items.Count(p => p.DeptID == deptId) > 0;
            if (!have)
            {
                Items.ForEach(p =>
                  {
                      have = have || p.IsHaveDept(deptId);

                  });
            }

            return have;

        }
        public List<string> GetNameList()
        {
            List<string> nl = new List<string>();
            nl.Add(DeptName);
            if (Items.Count > 0)
            {
                Items.ForEach(p =>
                {
                    nl.AddRange(p.GetNameList());
                });
            }
            return nl;
        }

        public List<long> GetIdList()
        {
            List<long> nl = new List<long>();
            nl.Add(DeptID);
            if (Items.Count > 0)
            {
                Items.ForEach(p =>
                {
                    nl.AddRange(p.GetIdList());
                });
            }
            return nl;
        }

        public DeptNode Clone()
        {

            var dept = (DeptNode)this.MemberwiseClone();
            dept.Items = new List<DeptNode>();
            return dept;
        }
    }


}
