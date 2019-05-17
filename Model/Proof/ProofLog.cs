using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Model.Sys;
namespace SG.Model.Proof
{
  public  class ProofLog
    {
        public int Id { get; set; }

        public DateTime LogDate { get; set; }
        public string Name { get; set; }

        public string Msg { get; set; }
       
    }
}
