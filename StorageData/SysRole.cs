namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysRole")]
    public partial class SysRole
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleNum { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }

        public int IsDelete { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
