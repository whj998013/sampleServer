namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class scgl_ybgx
    {
        [Key]
        [Column(Order = 0)]
        public long id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_sfk { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bh { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short bhpc { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4)]
        public string cocode { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(12)]
        public string gx { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(12)]
        public string bjmc { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte gxlb { get; set; }

        [Key]
        [Column(Order = 8)]
        public byte ypbz { get; set; }

        [Key]
        [Column(Order = 9)]
        public byte fgbz { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short gxsl { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short yh1 { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short yh2 { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_jbr { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_czr { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? gxrq { get; set; }

        [Key]
        [Column(Order = 15, TypeName = "smalldatetime")]
        public DateTime djrq { get; set; }

        public int? id_jt { get; set; }
    }
}
