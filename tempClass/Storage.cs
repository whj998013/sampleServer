namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Storage")]
    public partial class Storage
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string StorageNum { get; set; }

        [StringLength(50)]
        public string StorageName { get; set; }

        public int StorageType { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        [StringLength(200)]
        public string Action { get; set; }

        public int IsDelete { get; set; }

        public int Status { get; set; }

        public int IsForbid { get; set; }

        public int IsDefault { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
