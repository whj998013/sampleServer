namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class xt_zdcs
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string zdm { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short px { get; set; }

        [StringLength(50)]
        public string cs { get; set; }
    }
}
