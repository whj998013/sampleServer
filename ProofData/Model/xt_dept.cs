namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class xt_dept
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(16)]
        public string dept { get; set; }

        [Required]
        [StringLength(2)]
        public string lb { get; set; }

        [Required]
        [StringLength(4)]
        public string pym { get; set; }

        [Required]
        [StringLength(2)]
        public string deptkey { get; set; }

        public byte px { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime djrq { get; set; }

        [StringLength(10)]
        public string jbr { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? delrq { get; set; }
    }
}
