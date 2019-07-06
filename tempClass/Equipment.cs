namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public partial class Equipment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string SnNum { get; set; }

        [Required]
        [StringLength(50)]
        public string EquipmentName { get; set; }

        [Required]
        [StringLength(20)]
        public string EquipmentNum { get; set; }

        public int IsImpower { get; set; }

        [StringLength(20)]
        public string Flag { get; set; }

        public int IsDelete { get; set; }

        public int Status { get; set; }

        [Required]
        [StringLength(200)]
        public string CreateUser { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(400)]
        public string Remark { get; set; }
    }
}
