namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysDepart")]
    public partial class SysDepart
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string DepartNum { get; set; }

        [Required]
        [StringLength(20)]
        public string DepartName { get; set; }

        public int ChildCount { get; set; }

        [StringLength(20)]
        public string ParentNum { get; set; }

        public int Depth { get; set; }

        public int IsDelete { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
