using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Proof;
using System.Data.Entity;
namespace ProofData.Bll
{
    public class GyOper
    {
        public bool AddOrUpdataGlRecord(ProofTask task)
        {
            using ProofDataContext pdc = new ProofDataContext();
            var yd = pdc.ypgl_yd.FirstOrDefault(p => p.dydbh == task.Order.Dydbh);
            if (yd == null) return false;
            var gy = pdc.ypgl_gyzbjl.FirstOrDefault(p => p.id_yd == yd.id && p.task_id == task.Id);
            if (gy == null)
            {
                gy = new ypgl_gyzbjl()
                {
                    id_dept = 1,
                    id_yd = yd.id,
                    gg = "均码",
                    ry_gy = task.UserName,
                    ry_zb = "a",
                    fsj_gy = task.BeginDate,
                    jhsj_gy = task.NeedFinshDate,
                    task_id = task.Id,
                    sl = (short)task.Order.ProofNum,
                };
                pdc.ypgl_gyzbjl.Add(gy);
            }
            else
            {
                gy.ry_gy = task.UserName;
                gy.fsj_gy = task.BeginDate;
                gy.jhsj_gy = task.NeedFinshDate;
                gy.sl = (short)task.Order.ProofNum;
                gy.task_id = task.Id;
            }

            pdc.SaveChanges();
            return true;
        }
    }
}
