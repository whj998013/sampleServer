namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SnNum { get; set; }

        [Required]
        [StringLength(50)]
        public string BarCode { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public double Num { get; set; }

        public double MinNum { get; set; }

        public double MaxNum { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitNum { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitName { get; set; }

        [Required]
        [StringLength(50)]
        public string CateNum { get; set; }

        [StringLength(50)]
        public string CateName { get; set; }

        [StringLength(400)]
        public string Size { get; set; }

        [StringLength(200)]
        public string Color { get; set; }

        public double InPrice { get; set; }

        public double OutPrice { get; set; }

        public double AvgPrice { get; set; }

        public double NetWeight { get; set; }

        public double GrossWeight { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [StringLength(200)]
        public string PicUrl { get; set; }

        public int IsDelete { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(20)]
        public string CreateUser { get; set; }

        [StringLength(20)]
        public string StorageNum { get; set; }

        [StringLength(20)]
        public string DefaultLocal { get; set; }

        [StringLength(20)]
        public string CusNum { get; set; }

        [StringLength(30)]
        public string CusName { get; set; }

        [StringLength(50)]
        public string Display { get; set; }

        [Column(TypeName = "ntext")]
        public string Remark { get; set; }

        [StringLength(50)]
        public string Composition { get; set; }

        [StringLength(50)]
        public string Count { get; set; }
    }
}
