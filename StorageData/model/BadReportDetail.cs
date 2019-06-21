namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BadReportDetail")]
    public partial class BadReportDetail
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

        public double? Amount { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(20)]
        public string StorageNum { get; set; }

        [StringLength(20)]
        public string FromLocalNum { get; set; }

        [StringLength(20)]
        public string ToLocalNum { get; set; }
    }
}
