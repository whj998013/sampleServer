namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string PassWord { get; set; }

        [Required]
        [StringLength(40)]
        public string UserCode { get; set; }

        [Required]
        [StringLength(20)]
        public string RealName { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(11)]
        public string Mobile { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(20)]
        public string CreateIp { get; set; }

        [StringLength(15)]
        public string CreateUser { get; set; }

        public int LoginCount { get; set; }

        [StringLength(30)]
        public string Picture { get; set; }

        public DateTime UpdateTime { get; set; }

        public short IsDelete { get; set; }

        public short Status { get; set; }

        [StringLength(20)]
        public string DepartNum { get; set; }

        [Required]
        [StringLength(40)]
        public string ParentCode { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleNum { get; set; }

        [StringLength(20)]
        public string Remark { get; set; }
    }
}
