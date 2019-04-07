namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dy_gx_info
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string dydbh { get; set; }

        public int? bh { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short gs { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(12)]
        public string gx { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? gxrq { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "smalldatetime")]
        public DateTime djrq { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string xm { get; set; }

        [StringLength(50)]
        public string proofId { get; set; }
    }
}
