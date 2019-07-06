namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SupNum { get; set; }

        [Required]
        [StringLength(50)]
        public string SupName { get; set; }

        public int? SupType { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(20)]
        public string ContactName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string CreateUser { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [StringLength(50)]
        public string ContractNum { get; set; }

        public int IsDelete { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
