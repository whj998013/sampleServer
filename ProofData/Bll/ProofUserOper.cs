using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Utilities;
namespace ProofData.Bll
{
    public class ProofUserOper
    {


        public int GetrOrAddUser(string userName)
        {
            using (ProofDataContext pdc = new ProofDataContext())
            {
                string pym = userName.ToLower();
                var re = pdc.xt_ryb.Where(p => p.xm == userName).FirstOrDefault();
                if (re == null)
                {
                    int ghid = int.Parse(pdc.xt_ryb.Max(p => p.gh));
                    pdc.xt_ryb.Add(new xt_ryb
                    {
                        id_dept = 3,
                        rylb = "1",
                        gzlb = "1",
                        xm = userName,
                        pym = PinyinHelper.PinyinString(userName),
                        mm = "123",
                        xb = "1",
                        gh = (ghid + 1).ToString(),
                    });

                    pdc.SaveChanges();
                    re = pdc.xt_ryb.Where(p => p.xm == userName).FirstOrDefault();
                }
                return re.id;
            }


        }
    }
}
