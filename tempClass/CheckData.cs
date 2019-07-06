namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CheckData")]
    public partial class CheckData
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNum { get; set; }

        [StringLength(50)]
        public string LocalNum { get; set; }

        [StringLength(50)]
        public string LocalName { get; set; }

        [StringLength(50)]
        public string StorageNum { get; set; }

        [StringLength(50)]
        public string ProductNum { get; set; }

        [StringLength(50)]
        public string BarCode { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string BatchNum { get; set; }

        public double? LocalQty { get; set; }

        public double? FirstQty { get; set; }

        public double? SecondQty { get; set; }

        public double? DifQty { get; set; }

        [StringLength(50)]
        public string FirstUser { get; set; }

        [StringLength(50)]
        public string SecondUser { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
