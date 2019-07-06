namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportParams
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ParamNum { get; set; }

        [Required]
        [StringLength(50)]
        public string ReportNum { get; set; }

        [StringLength(50)]
        public string InputNo { get; set; }

        [StringLength(50)]
        public string ParamName { get; set; }

        [StringLength(50)]
        public string ShowName { get; set; }

        [StringLength(50)]
        public string ParamType { get; set; }

        [StringLength(1000)]
        public string ParamData { get; set; }

        [StringLength(100)]
        public string DefaultValue { get; set; }

        [StringLength(200)]
        public string ParamElement { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
