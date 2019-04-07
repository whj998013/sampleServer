namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ypgl_gx
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_yd { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte px { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(8)]
        public string gxlb { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(20)]
        public string gx { get; set; }

        [StringLength(10)]
        public string czr { get; set; }

        public int? id_czr { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal sl { get; set; }

        [StringLength(8)]
        public string dw { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal dj { get; set; }

        public decimal? gj { get; set; }

        [StringLength(20)]
        public string dim { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int gxjs { get; set; }
    }
}
