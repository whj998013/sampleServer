namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ypgl_zb
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_gy { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string ry_zb { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fsj { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ssj { get; set; }

        public decimal? mnsj { get; set; }

        [StringLength(20)]
        public string jx { get; set; }

        [StringLength(10)]
        public string bh { get; set; }

        [StringLength(16)]
        public string zx { get; set; }
    }
}
