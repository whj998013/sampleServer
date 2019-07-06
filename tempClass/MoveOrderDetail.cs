namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MoveOrderDetail")]
    public partial class MoveOrderDetail
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

        public double? InPrice { get; set; }

        public double? Amout { get; set; }

        public int IsPick { get; set; }

        public double RealNum { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string StorageNum { get; set; }

        [StringLength(50)]
        public string FromLocalNum { get; set; }

        [StringLength(50)]
        public string ToLocalNum { get; set; }
    }
}
