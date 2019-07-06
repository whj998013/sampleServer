namespace tempClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InOrderView")]
    public partial class InOrderView
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
        public double Num { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsPick { get; set; }

        [Key]
        [Column(Order = 7)]
        public double RealNum { get; set; }

        [Key]
        [Column(Order = 8)]
        public double InPrice { get; set; }

        [Key]
        [Column(Order = 9)]
        public double Amount { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string LocalNum { get; set; }

        [StringLength(30)]
        public string LocalName { get; set; }

        [StringLength(50)]
        public string StorageNum { get; set; }

        [StringLength(50)]
        public string StorageName { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Count { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string SupNum { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(100)]
        public string SupName { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsDelete { get; set; }

        [StringLength(50)]
        public string CreateUser { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InType { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductType { get; set; }

        [StringLength(400)]
        public string Remark { get; set; }

        public double? Cl { get; set; }

        public double? Ca { get; set; }

        public double? Cb { get; set; }

        [StringLength(20)]
        public string RGB { get; set; }

        [StringLength(400)]
        public string Size { get; set; }

        [StringLength(705)]
        public string SeachKey { get; set; }

        public double? InStorNum { get; set; }
    }
}
