namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocalProductView")]
    public partial class LocalProductView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
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

        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string BarCode { get; set; }

        [StringLength(50)]
        public string BatchNum { get; set; }

        [Key]
        [Column(Order = 2)]
        public double Num { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string CreateUser { get; set; }

        [StringLength(50)]
        public string CreateName { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        [StringLength(50)]
        public string Count { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string UName { get; set; }

        [StringLength(50)]
        public string DName { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        [StringLength(455)]
        public string SeachKey { get; set; }

        [StringLength(50)]
        public string SupName { get; set; }

        public double? Cl { get; set; }

        public double? Ca { get; set; }

        public double? Cb { get; set; }

        [StringLength(20)]
        public string RGB { get; set; }

        [Key]
        [Column(Order = 4)]
        public double InPrice { get; set; }

        [Key]
        [Column(Order = 5)]
        public double Amount { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InStorId { get; set; }
    }
}
