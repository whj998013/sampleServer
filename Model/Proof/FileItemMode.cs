using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Proof
{
    public class FileItemModel
    {
        ///<summary>
        /// 按人名查询早晚打卡.txt
        /// </summary>
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }


        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "proofStyleId")]
        public string ProofStyleId { get; set; }
    }
}
