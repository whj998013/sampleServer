using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProofData.Bll;

namespace ProofBLL
{
    public class ProofClient
    {
        public List<string> GetClients()
        {
            List<string> ns = new ClientOper().GetClientList();
            return ns;

        }
    }
}
