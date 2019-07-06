using SG.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;
namespace ProofBLL
{
   public class ProofFileOper
    {
        User user;
        public ProofFileOper(User u)
        {
            user = u;
        }
        public bool DeleteProofFile(int id)
        {
            using (SunginDataContext sdc=new SunginDataContext())
            {
                var re = sdc.ProofFiles.Where(p => p.Id == id && p.CreateUser == user.UserName).SingleOrDefault();

                if (re != null)
                {
                    re.Delete(user.UserName);
                    sdc.SaveChanges();
                    return true;
                }
                
            }

            return false;
        }
    }
}
