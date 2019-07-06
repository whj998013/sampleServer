namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InStorDetail")]
    public partial class InStorDetail
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

        public double Num { get; set; }

        public int IsPick { get; set; }

        public double RealNum { get; set; }

        public double InPrice { get; set; }

        public double Amount { get; set; }

        [StringLength(50)]
        public string ContractOrder { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string LocalNum { get; set; }

        [StringLength(50)]
        public string StorageNum { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Count { get; set; }

        public double? Cl { get; set; }

        public double? Ca { get; set; }

        public double? Cb { get; set; }

        [StringLength(20)]
        public string RGB { get; set; }

        [StringLength(400)]
        public string Size { get; set; }
    }
}
