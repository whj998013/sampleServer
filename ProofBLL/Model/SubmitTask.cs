using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProofBLL
{
    public class SubmitTask
    {
        /// 
        /// </summary>
        [DataMember(Name = "nextTaskId")]
        public int NextTaskId { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "nextProcessId")]
        public int NextProcessId { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "nextWorkerName")]
        public string NextWorkerName { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "nextProcessName")]
        public string NextProcessName { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "proofId")]
        public string ProofId { get; set; }

        ///<summary>
        /// 
        /// </summary>tTaskId")]
        public int TaskId { get; set; }
    }




}
