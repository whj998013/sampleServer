namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ypgl_gyzbjl
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_dept { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_yd { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string gg { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string ry_gy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fsj_gy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? jhsj_gy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ssj_gy { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string ry_zb { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fsj_zb { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? jhsj_zb { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ssj_zb { get; set; }

        public short? csgs { get; set; }

        public byte? speed { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short sl { get; set; }
    }
}
