namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string CusNum { get; set; }

        [Required]
        [StringLength(20)]
        public string CusName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Fax { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public int? CusType { get; set; }

        public int? IsDelete { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(20)]
        public string CreateUser { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
