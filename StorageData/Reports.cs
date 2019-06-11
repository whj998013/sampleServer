namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reports
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ReportNum { get; set; }

        [StringLength(50)]
        public string ReportName { get; set; }

        public int? ReportType { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        [StringLength(4000)]
        public string DataSource { get; set; }

        public int? DsType { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        public int? IsDelete { get; set; }

        public int? Status { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
