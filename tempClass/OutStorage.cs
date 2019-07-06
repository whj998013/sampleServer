namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutStorage")]
    public partial class OutStorage
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNum { get; set; }

        public int OutType { get; set; }

        public int ProductType { get; set; }

        [Required]
        [StringLength(50)]
        public string StorageNum { get; set; }

        [Required]
        [StringLength(50)]
        public string CusNum { get; set; }

        [Required]
        [StringLength(100)]
        public string CusName { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string ContractOrder { get; set; }

        public double? Num { get; set; }

        public double? Amount { get; set; }

        public double? Weight { get; set; }

        public DateTime SendDate { get; set; }

        public int Status { get; set; }

        public int IsDelete { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string CreateUser { get; set; }

        [StringLength(50)]
        public string AuditUser { get; set; }

        public DateTime? AuditeTime { get; set; }

        [StringLength(50)]
        public string PrintUser { get; set; }

        public DateTime? PrintTime { get; set; }

        [StringLength(400)]
        public string Reason { get; set; }

        public int OperateType { get; set; }

        [Required]
        [StringLength(50)]
        public string EquipmentNum { get; set; }

        [Required]
        [StringLength(50)]
        public string EquipmentCode { get; set; }

        [StringLength(400)]
        public string Remark { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }
    }
}
