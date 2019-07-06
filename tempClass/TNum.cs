namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TNum")]
    public partial class TNum
    {
        public int ID { get; set; }

        public int Num { get; set; }

        public int MinNum { get; set; }

        public int MaxNum { get; set; }

        [StringLength(20)]
        public string Day { get; set; }

        [Required]
        [StringLength(50)]
        public string TabName { get; set; }
    }
}
