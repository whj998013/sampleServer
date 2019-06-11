using ProofBLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using System.Data.Entity;
using SampleDataOper;
using ProofData;
namespace ProofBLL.Bll
{
    public class ProofRecord
    {
        SunginDataContext sdc = new SunginDataContext();
        ProofDataContext pdc = new ProofDataContext();
        public List<PfRecord> GetProofRecord(string ProofOrderId)
        {
            List<PfRecord> pflist = new List<PfRecord>();
            var order = sdc.ProofOrders.SingleOrDefault(p => p.ProofOrderId == ProofOrderId);
            
            var tlist =  sdc.ProofTasks.Where(p => p.Order.ProofOrderId == ProofOrderId).ToList();
            if (tlist != null)
            {
                tlist.ForEach(p =>
                           {
                               if (!p.IsDelete)
                               {
                                   PfRecord np = new PfRecord
                                   {
                                       WorkerName = p.UserName,
                                       ProcessName = p.Process.ProcessName,
                                       BeginDate = p.BeginDate,
                                       FinshDate = p.FinshDate
                                   };
                                   pflist.Add(np);

                               }

                           });

            }

            //取得打样系统数据
            if (order.Dydbh != "")
            {
                var dydlist = pdc.dy_gx_info.Where(p => p.dydbh == order.Dydbh).ToList();
                dydlist.ForEach(p =>
                {
                    PfRecord np = new PfRecord
                    {
                        WorkerName = p.xm,
                        ProcessName = p.gx,
                        BeginDate = p.djrq,
                        FinshDate = p.gxrq,
                        WorkTime=p.gs,
                    };
                    pflist.Add(np);

                });

            }


            return pflist;

        }
       
    }
}
