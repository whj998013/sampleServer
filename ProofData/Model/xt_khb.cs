namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class xt_khb
    {
        public int id { get; set; }

        [StringLength(16)]
        public string khmc { get; set; }

        [StringLength(40)]
        public string address { get; set; }

        [StringLength(40)]
        public string tel { get; set; }

        [StringLength(8)]
        public string pym { get; set; }

        [StringLength(40)]
        public string bank { get; set; }

        public byte? bz_dd { get; set; }

        public byte? bz_sx { get; set; }

        public byte? bz_fl { get; set; }

        public byte? bz_cp { get; set; }

        public byte? bz_yl { get; set; }

        [StringLength(30)]
        public string khqc { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? rq { get; set; }

        public byte? bz_wf { get; set; }
    }
}
