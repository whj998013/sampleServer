using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Sys
{
   public class FactryRoleWorker:BaseModel
    {
        public int Id { get; set; }

        public string JobName { get; set; }
        
        public string WorkName { get; set; }

        public Worker Worker { get; set; }

        public Role Role { get; set; }
       
        public Job Job { get; set; }

    }
}
