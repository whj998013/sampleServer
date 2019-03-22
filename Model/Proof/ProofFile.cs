using SG.Interface.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Proof
{
   public class ProofFile:BaseModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string ProofStyleId { get; set; }
        public FileType FileType { get; set; }


    }
}
