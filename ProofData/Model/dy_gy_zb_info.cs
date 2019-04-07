namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dy_gy_zb_info
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_dept { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string dydbh { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_kh { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(24)]
        public string kh { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string km { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string cf { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(20)]
        public string szi { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(24)]
        public string khkh { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short cpz { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(10)]
        public string yplb { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_khb { get; set; }

        [Key]
        [Column(Order = 12, TypeName = "smalldatetime")]
        public DateTime rq_dj { get; set; }

        [Key]
        [Column(Order = 13, TypeName = "smalldatetime")]
        public DateTime rq_jh { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(10)]
        public string ry_sj { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(10)]
        public string ry_gy { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(10)]
        public string ry_zb { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(10)]
        public string ry_jb { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(10)]
        public string ry_yw { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(10)]
        public string zx { get; set; }

        [Key]
        [Column(Order = 20, TypeName = "smalldatetime")]
        public DateTime tprq { get; set; }

        public byte? tkbz { get; set; }

        [Key]
        [Column(Order = 21, TypeName = "smalldatetime")]
        public DateTime gytprq { get; set; }

        public int? pj_sh { get; set; }

        public int? pj_zd { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? wcsj { get; set; }

        public short? wclx { get; set; }

        [StringLength(50)]
        public string dim { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(20)]
        public string gg { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(10)]
        public string gy_name { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fsj_gy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ssj_gy { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(20)]
        public string zb_name { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? fsj { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ssj { get; set; }

        public decimal? mnsj { get; set; }

        [StringLength(20)]
        public string jx { get; set; }

        [StringLength(10)]
        public string bh { get; set; }
    }
}
