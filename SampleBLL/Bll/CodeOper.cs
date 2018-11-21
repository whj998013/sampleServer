using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBLL;
using SampleDataOper;
using Model.Sys;
using Model.Sample;
using SG.Interface.Sys;

namespace SampleBLL
{
    public class CodeOper
    {
        public static void AddCode(Code _code)
        {
            using (SampleContext sc = new SampleContext())
            {                
                {
                    var code = sc.Codes.Where(p => p.CodeName == _code.CodeName).SingleOrDefault();
                    if (code == null)
                    {
                        sc.Codes.Add(_code);
                    }else code.UseCount++;
                }
                sc.SaveChanges();
            }
        }

        public static void AddCode(List<Code> codes)
        {
            using (SampleContext sc = new SampleContext())
            {

                foreach (var m in codes)
                {                    
                    var code = sc.Codes.Where(p => p.CodeName == m.CodeName).SingleOrDefault();
                    if (code == null)
                    {
                        sc.Codes.Add(m);
                    }
                    else code.UseCount++;
                }
                sc.SaveChanges();
            }
        }

        public static object GetColorList()
        {
            using (SampleContext sc = new SampleContext())
            {
                var list = sc.Codes.Where(p => p.Type == CodeType.Color).OrderByDescending(t=>t.UseCount).Select(p => p.CodeName).ToList();
                return list;
            }
        }

        public static object GetSizeList()
        {
            using (SampleContext sc = new SampleContext())
            {
                var list = sc.Codes.Where(p => p.Type == CodeType.Size).OrderByDescending(t => t.UseCount).Select(p => p.CodeName).ToList();
                return list;
            }
        }

        public static object GetGaugeList()
        {
            using (SampleContext sc = new SampleContext())
            {
                var list = sc.Codes.Where(p => p.Type == CodeType.Gauge).OrderByDescending(t => t.UseCount).Select(p => p.CodeName).ToList();
                return list;
            }
        }

        public static object GetKindsList()
        {
            using (SampleContext sc = new SampleContext())
            {
                var list = sc.Codes.Where(p => p.Type == CodeType.Kinds).OrderByDescending(t => t.UseCount).Select(p => p.CodeName).ToList();
                return list;
            }
        }


        public static object GetMaterialList()
        {
            using (SampleContext sc = new SampleContext())
            {
                //var list = sc.Codes.Where(p => p.Type == CodeType.Material).OrderByDescending(t => t.UseCount).Select(p => p.CodeName).ToList();
                var list = sc.Materials.OrderByDescending(p=>p.UseCount).Select(p => new { p.CnName, p.EnName, p.UseCount}).ToList();
                return list;
            }
        }

        public static object GetTagList()
        {
            using (SampleContext sc = new SampleContext())
            {
                var list = sc.Codes.Where(p => p.Type == CodeType.Tag).OrderByDescending(t => t.UseCount).Select(p => new { name = p.CodeName, color = p.Value1 }).ToList();
                return list;
            }
        }
    }
}
