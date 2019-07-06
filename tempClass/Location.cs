namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string LocalNum { get; set; }

        [Required]
        [StringLength(20)]
        public string LocalBarCode { get; set; }

        [Required]
        [StringLength(30)]
        public string LocalName { get; set; }

        [Required]
        [StringLength(20)]
        public string StorageNum { get; set; }

        public int StorageType { get; set; }

        public int LocalType { get; set; }

        [StringLength(100)]
        public string Rack { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitNum { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitName { get; set; }

        [StringLength(4000)]
        public string Remark { get; set; }

        public int IsForbid { get; set; }

        public int IsDefault { get; set; }

        public int IsDelete { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
