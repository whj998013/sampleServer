namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sequence")]
    public partial class Sequence
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string SN { get; set; }

        [Required]
        [StringLength(50)]
        public string TabName { get; set; }

        public int FirstType { get; set; }

        [StringLength(100)]
        public string FirstRule { get; set; }

        public int? FirstLength { get; set; }

        public int? SecondType { get; set; }

        [StringLength(100)]
        public string SecondRule { get; set; }

        public int? SecondLength { get; set; }

        public int? ThirdType { get; set; }

        [StringLength(100)]
        public string ThirdRule { get; set; }

        public int? ThirdLength { get; set; }

        public int? FourType { get; set; }

        [StringLength(100)]
        public string FourRule { get; set; }

        public int? FourLength { get; set; }

        [StringLength(10)]
        public string JoinChar { get; set; }

        [StringLength(100)]
        public string Sample { get; set; }

        [StringLength(100)]
        public string CurrentValue { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
