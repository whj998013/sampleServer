namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryBook")]
    public partial class InventoryBook
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductNum { get; set; }

        [Required]
        [StringLength(50)]
        public string BarCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string BatchNum { get; set; }

        public double Num { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactOrder { get; set; }

        [StringLength(50)]
        public string FromLocalNum { get; set; }

        [StringLength(50)]
        public string ToLocalNum { get; set; }

        [StringLength(50)]
        public string StoreNum { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string CreateUser { get; set; }
    }
}
