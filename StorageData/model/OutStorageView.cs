namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutStorageView")]
    public partial class OutStorageView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SnNum { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string OrderNum { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string BarCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ProductNum { get; set; }

        [StringLength(50)]
        public string BatchNum { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string LocalNum { get; set; }

        [StringLength(50)]
        public string StorageNum { get; set; }

        [Key]
        [Column(Order = 6)]
        public double Num { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsPick { get; set; }

        [Key]
        [Column(Order = 8)]
        public double RealNum { get; set; }

        public double? OutPrice { get; set; }

        public double? Amount { get; set; }

        [StringLength(50)]
        public string ContractOrder { get; set; }

        [StringLength(50)]
        public string ContractSn { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string Count { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string OutUName { get; set; }

        [StringLength(50)]
        public string OutDName { get; set; }

        [StringLength(50)]
        public string OutUid { get; set; }

        public DateTime? AuditeTime { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(100)]
        public string CusName { get; set; }

        [StringLength(50)]
        public string InUName { get; set; }

        [StringLength(50)]
        public string InUid { get; set; }

        [StringLength(50)]
        public string InDName { get; set; }

        [Key]
        [Column(Order = 11)]
        public double InPrice { get; set; }

        public string RGB { get; set; }

        public int Status { get; set; }
    }
}
