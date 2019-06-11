namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysRelation")]
    public partial class SysRelation
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleNum { get; set; }

        [Required]
        [StringLength(20)]
        public string ResNum { get; set; }

        public short ResType { get; set; }
    }
}
