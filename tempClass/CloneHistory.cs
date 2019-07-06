namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CloneHistory")]
    public partial class CloneHistory
    {
        [Key]
        public int CloneID { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNum { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Sn { get; set; }

        [StringLength(50)]
        public string StorageNum { get; set; }

        [StringLength(50)]
        public string StorageName { get; set; }

        [StringLength(50)]
        public string LocalNum { get; set; }

        [StringLength(50)]
        public string LocalName { get; set; }

        public int? LocalType { get; set; }

        [StringLength(50)]
        public string ProductNum { get; set; }

        [StringLength(50)]
        public string BarCode { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string BatchNum { get; set; }

        public double Num { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string CreateUser { get; set; }

        [StringLength(50)]
        public string CreateName { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
