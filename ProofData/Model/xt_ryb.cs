namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class xt_ryb
    {
        public int id { get; set; }

        public int id_dept { get; set; }

        [Required]
        [StringLength(1)]
        public string rylb { get; set; }

        [Required]
        [StringLength(1)]
        public string gzlb { get; set; }

        [Required]
        [StringLength(10)]
        public string xm { get; set; }

        [Required]
        [StringLength(6)]
        public string gh { get; set; }

        [Required]
        [StringLength(5)]
        public string pym { get; set; }

        [Required]
        [StringLength(1)]
        public string xb { get; set; }

        [StringLength(10)]
        public string city { get; set; }

        [StringLength(18)]
        public string zjhm { get; set; }

        [StringLength(8)]
        public string mm { get; set; }
    }
}
