using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Utilities;
namespace ProofData.Bll
{
    public class ClientOper
    {

        public List<string> GetClientList()
        {
            using ProofDataContext pdc = new ProofDataContext();
            var ns = pdc.xt_khb.Select(p => p.khmc).ToList();

            return ns;

        }

        public int GetOrAddClient(string clientName)
        {
            using ProofDataContext pdc = new ProofDataContext();
            string c = clientName.ToLower();
            string pym = PinyinHelper.PinyinString(clientName).ToLower();
            var re = pdc.xt_khb.Where(p => p.khmc.ToLower() == c).FirstOrDefault();
            if (re == null)
            {
                pdc.xt_khb.Add(new xt_khb
                {
                    khmc = clientName,
                    khqc = clientName,
                    rq = DateTime.Now,
                    bz_dd = 1,
                    address = "内部同步客户",
                    pym = pym == "" ? clientName : pym,
                });
                pdc.SaveChanges();
                re = pdc.xt_khb.Where(p => p.khmc.ToLower() == c).FirstOrDefault();
            }
            return re.id;

        }
    }
}
