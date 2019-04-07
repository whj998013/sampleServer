using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Proof
{

    [DataContract]
    public class ProofObj
    {
        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "ProofOrderId")]
        public string ProofOrderId { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "ProofStyleId")]
        public string ProofStyleId { get; set; }

        ///<summary>
        /// 王汉君
        /// </summary>
        [DataMember(Name = "UserName")]
        public string UserName { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "ClentName")]
        public string ClentName { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "ProofStyleNo")]
        public string ProofStyleNo { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "ClientNo")]
        public string ClientNo { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "StyleName")]
        public string StyleName { get; set; }

        ///<summary>
        /// 齐码样
        /// </summary>
        [DataMember(Name = "proofType")]
        public string ProofType { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "Counts")]
        public string Counts { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "Material")]
        public string Material { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "Weight")]
        public int Weight { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "Gauge")]
        public string Gauge { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "FileList")]
        public List<FileItemModel> FileListItems { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "FinshDate")]
        public DateTime FinshDate { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "ProofNum")]
        public int ProofNum { get; set; }
        [DataMember(Name = "DesignatedGY")]
        public string DesignatedGY { get; set; }
        [DataMember(Name = "DesignatedCX")]
        public string DesignatedCX { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(Name = "Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 紧急度
        /// </summary>
        [DataMember(Name = "Urgency")]
        public string Urgency { get; set; }
    }

}
