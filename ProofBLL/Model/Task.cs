using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProofBLL
{
    public class Task
    {
        public int Id { get; set; }
     
        [DataMember(Name = "taskNo")]
        public string TaskNo { get; set; }
        [DataMember(Name = "upTaskNo")]
        public string UpTaskNo { get; set; }

        public string ProofOrderId { get; set; }
        public string WorkerName { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }

        public DateTime NeedFinshDate { get; set; }

        public DateTime? BeginDate { get; set; }
               
        [DataMember(Name = "status")]
        public string Status { get; set; }

    }
}
