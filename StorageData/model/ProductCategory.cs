namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public int ID { get; set; }

        [Required]
        [StringLength(15)]
        public string CateNum { get; set; }

        [StringLength(50)]
        public string CateName { get; set; }

        public int IsDelete { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(20)]
        public string CreateUser { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
