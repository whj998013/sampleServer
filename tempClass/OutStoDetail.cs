namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutStoDetail")]
    public partial class OutStoDetail
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SnNum { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNum { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string BarCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductNum { get; set; }

        [StringLength(50)]
        public string BatchNum { get; set; }

        [Required]
        [StringLength(50)]
        public string LocalNum { get; set; }

        [StringLength(50)]
        public string StorageNum { get; set; }

        public double Num { get; set; }

        public int IsPick { get; set; }

        public double RealNum { get; set; }

        public double? OutPrice { get; set; }

        public double? Amount { get; set; }

        [StringLength(50)]
        public string ContractOrder { get; set; }

        [StringLength(50)]
        public string ContractSn { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string Count { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Size { get; set; }
    }
}
