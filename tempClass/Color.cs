namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Color")]
    public partial class Color
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string RGB { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public double Lab_L { get; set; }

        public double Lab_a { get; set; }

        public double Lab_b { get; set; }
    }
}