namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Measure")]
    public partial class Measure
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SN { get; set; }

        [StringLength(50)]
        public string MeasureNum { get; set; }

        [StringLength(50)]
        public string MeasureName { get; set; }
    }
}
