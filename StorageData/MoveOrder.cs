namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MoveOrder")]
    public partial class MoveOrder
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNum { get; set; }

        public int MoveType { get; set; }

        public int ProductType { get; set; }

        [Required]
        [StringLength(50)]
        public string StorageNum { get; set; }

        [Required]
        [StringLength(50)]
        public string ContractOrder { get; set; }

        public int Status { get; set; }

        public int IsDelete { get; set; }

        public double Num { get; set; }

        public double? Amout { get; set; }

        public double? Weight { get; set; }

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

        public int OperateType { get; set; }

        [Required]
        [StringLength(20)]
        public string EquipmentNum { get; set; }

        [Required]
        [StringLength(20)]
        public string EquipmentCode { get; set; }

        [StringLength(400)]
        public string Remark { get; set; }
    }
}
