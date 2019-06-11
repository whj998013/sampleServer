namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CheckStockInfo")]
    public partial class CheckStockInfo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNum { get; set; }

        [Required]
        [StringLength(50)]
        public string StorageNum { get; set; }

        [Required]
        [StringLength(50)]
        public string TargetNum { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
