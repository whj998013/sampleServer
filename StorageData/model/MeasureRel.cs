namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MeasureRel")]
    public partial class MeasureRel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SN { get; set; }

        [StringLength(50)]
        public string MeasureSource { get; set; }

        [StringLength(50)]
        public string MeasureTarget { get; set; }

        public double? Rate { get; set; }
    }
}
