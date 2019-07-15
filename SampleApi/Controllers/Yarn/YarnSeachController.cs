using SunginData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StorageData;
using YarnStockBLL;
using SG.Interface;
using SG.Utilities;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace SampleApi.Controllers.Yarn
{
    [Author]
    public class YarnSeachController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetOutList(dynamic obj)
        {
            string id = obj.BatchNum;
            if (id ==null||id=="") return BadRequest();
            var re = YarnOper.GetOutView(id).Select(p => new { p.ProductName, p.OutPrice,p.Num, p.Amount, p.OutUName, p.OutDName, p.CreateTime });
            return Ok(re);
        }
        [HttpPost]
        public IHttpActionResult GetYarnList(SeachObj obj)
        {
            if (obj == null) return BadRequest();

            var exp = PredicateBuilder.True<LocalProductView>().And(t => t.Num > 0);
            if (obj.Key != null && obj.Key != "")
            {
                obj.Key.Split(' ').ToList().ForEach(p =>
                           {
                               exp = exp.And(e => e.SeachKey.Contains(p));
                           });
            }
            
            else obj.Key = "";
            SeachReturnObj sr = new SeachReturnObj();
            sr.Result = YarnOper.GetYarnListDesc(out int count, exp.Compile(), p => p.CreateTime, obj.PageId, obj.PageSize);
            obj.Total = count;
            sr.SeachObj = obj;
            return Ok(sr);
        }

        [HttpPost]
        public IHttpActionResult GetLabYarnList(SeachObj obj)
        {
            System.Diagnostics.Debug.WriteLine("查询 L={0} A={1} B{2}", obj.Lab.L, obj.Lab.A, obj.Lab.B);
            var exp = PredicateBuilder.True<LocalProductView>().And(t => t.Num > 0);
            if (obj.Key != "")
            {
                obj.Key.Split(' ').ToList().ForEach(p =>
                {
                    exp = exp.And(e => e.SeachKey.Contains(p));
                });
            }

            var list = YarnOper.GetYarnListDesc(out int count, exp.Compile(), p => p.CreateTime);
            ConcurrentBag<LabReturnView> lrv = new ConcurrentBag<LabReturnView>();

            Parallel.ForEach<LocalProductView>(list, p =>
            {
                var labv = p.ToSon<LocalProductView, LabReturnView>();
                labv.Sc = Math.Round(LabDelta.Delta_E00((double)p.Cl, (double)p.Ca, (double)p.Cb, obj.Lab.L, obj.Lab.A, obj.Lab.B), 2);
                lrv.Add(labv);
            });

            SeachReturnObj sr = new SeachReturnObj();
            sr.Result = lrv.Where(p => p.Sc <= 20).OrderBy(p => p.Sc).Take(100);
            obj.Total = count;
            sr.SeachObj = obj;
            System.Diagnostics.Debug.WriteLine("查询完成，返回.");
            return Ok(sr); 

        }

    }

    public class LabReturnView : LocalProductView
    {
        public double Sc { get; set; }
    }

}
