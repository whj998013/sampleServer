namespace ProofData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class scgl_bh
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bh { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short bhpc { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string cocode { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_dept { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_dd { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_ddkh { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_pc { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short bjxh { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short scbz { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(20)]
        public string sz { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(12)]
        public string gg { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(20)]
        public string ghpc { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dyrq { get; set; }

        [Key]
        [Column(Order = 12, TypeName = "smalldatetime")]
        public DateTime tcrq { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(10)]
        public string tcjbr { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short sl { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_czr { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(5)]
        public string jth { get; set; }

        [Key]
        [Column(Order = 17)]
        public byte ypbz { get; set; }

        [Key]
        [Column(Order = 18)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short id_tcsfk { get; set; }

        [Key]
        [Column(Order = 19)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_wfpc { get; set; }

        public byte? ydbz { get; set; }
    }
}
