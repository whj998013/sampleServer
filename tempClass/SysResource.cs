namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysResource")]
    public partial class SysResource
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string ResNum { get; set; }

        [Required]
        [StringLength(20)]
        public string ResName { get; set; }

        [StringLength(20)]
        public string ParentNum { get; set; }

        public int Depth { get; set; }

        [StringLength(100)]
        public string ParentPath { get; set; }

        public int ChildCount { get; set; }

        public int Sort { get; set; }

        public short IsHide { get; set; }

        public short IsDelete { get; set; }

        [Required]
        [StringLength(200)]
        public string Url { get; set; }

        [Required]
        [StringLength(15)]
        public string CssName { get; set; }

        public DateTime CreateTime { get; set; }

        public short Depart { get; set; }

        public short ResType { get; set; }

        public DateTime UpdateTime { get; set; }

        [StringLength(20)]
        public string CreateUser { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }

        [StringLength(20)]
        public string CreateIp { get; set; }

        [StringLength(20)]
        public string UpdateIp { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
