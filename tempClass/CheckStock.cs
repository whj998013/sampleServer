namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CheckStock")]
    public partial class CheckStock
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderNum { get; set; }

        public int Type { get; set; }

        public int ProductType { get; set; }

        [Required]
        [StringLength(50)]
        public string StorageNum { get; set; }

        [Required]
        [StringLength(50)]
        public string ContractOrder { get; set; }

        public int Status { get; set; }

        public double LocalQty { get; set; }

        public double CheckQty { get; set; }

        public int IsDelete { get; set; }

        public int IsComplete { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(20)]
        public string CreateUser { get; set; }

        [StringLength(20)]
        public string AuditUser { get; set; }

        public DateTime? AuditeTime { get; set; }

        [StringLength(20)]
        public string PrintUser { get; set; }

        public DateTime? PrintTime { get; set; }

        [StringLength(400)]
        public string Reason { get; set; }

        public int? OperateType { get; set; }

        [StringLength(20)]
        public string EquipmentNum { get; set; }

        [StringLength(20)]
        public string EquipmentCode { get; set; }

        [StringLength(400)]
        public string Remark { get; set; }
    }
}
