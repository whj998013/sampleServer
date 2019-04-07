namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ypgl_yd
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int id_dept { get; set; }

        [Required]
        [StringLength(10)]
        public string dydbh { get; set; }

        public int id_kh { get; set; }

        [Required]
        [StringLength(24)]
        public string kh { get; set; }

        [Required]
        [StringLength(30)]
        public string km { get; set; }

        [Required]
        [StringLength(50)]
        public string cf { get; set; }

        [Required]
        [StringLength(20)]
        public string szi { get; set; }

        [Required]
        [StringLength(24)]
        public string khkh { get; set; }

        public short cpz { get; set; }

        [Required]
        [StringLength(10)]
        public string yplb { get; set; }

        public int id_khb { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime rq_dj { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime rq_jh { get; set; }

       
        [StringLength(10)]
        public string ry_sj { get; set; }

      
        [StringLength(10)]
        public string ry_gy { get; set; }

       
        [StringLength(10)]
        public string ry_zb { get; set; }

        [Required]
        [StringLength(10)]
        public string ry_jb { get; set; }

        [Required]
        [StringLength(10)]
        public string ry_yw { get; set; }

        [Required]
        [StringLength(10)]
        public string zx { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime tprq { get; set; }

        public byte? tkbz { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime gytprq { get; set; }

        public int? pj_sh { get; set; }

        public int? pj_zd { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? wcsj { get; set; }

        public short? wclx { get; set; }

        [StringLength(50)]
        public string dim { get; set; }

        [StringLength(50)]
        public string proofId { get; set; }
    }
}
