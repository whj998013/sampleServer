namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CusAddress")]
    public partial class CusAddress
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string SnNum { get; set; }

        [Required]
        [StringLength(20)]
        public string CusNum { get; set; }

        [StringLength(200)]
        public string Contact { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        public int IsDelete { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(20)]
        public string CreateUser { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
