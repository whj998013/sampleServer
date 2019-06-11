namespace StorageData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutOrderView")]
    public partial class OutOrderView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SnNum { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string OrderNum { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string BarCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ProductNum { get; set; }

        [StringLength(50)]
        public string BatchNum { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string LocalNum { get; set; }

        [StringLength(50)]
        public string StorageNum { get; set; }

        [Key]
        [Column(Order = 6)]
        public double Num { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsPick { get; set; }

        [Key]
        [Column(Order = 8)]
        public double RealNum { get; set; }

        public double? OutPrice { get; set; }

        public double? Amount { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string Count { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string CusNum { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(100)]
        public string CusName { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OutType { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductType { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsDelete { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        [Key]
        [Column(Order = 15)]
        public DateTime SendDate { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Status { get; set; }

        [StringLength(400)]
        public string Remark { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(30)]
        public string LocalName { get; set; }

        [StringLength(50)]
        public string StorageName { get; set; }

        [StringLength(400)]
        public string Size { get; set; }
    }
}
