namespace ProofData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProofDataContext : DbContext
    {
        public ProofDataContext()
            : base("name=ProofDataContext")
        {
        }

        public virtual DbSet<xt_dept> xt_dept { get; set; }
        public virtual DbSet<xt_khb> xt_khb { get; set; }
        public virtual DbSet<xt_ryb> xt_ryb { get; set; }
        public virtual DbSet<ypgl_yd> ypgl_yd { get; set; }
        public virtual DbSet<scgl_bh> scgl_bh { get; set; }
        public virtual DbSet<scgl_ybgx> scgl_ybgx { get; set; }
        public virtual DbSet<xt_zdcs> xt_zdcs { get; set; }
        public virtual DbSet<ypgl_gx> ypgl_gx { get; set; }
        public virtual DbSet<ypgl_gxczrback> ypgl_gxczrback { get; set; }
        public virtual DbSet<ypgl_gyzbjl> ypgl_gyzbjl { get; set; }
        public virtual DbSet<ypgl_zb> ypgl_zb { get; set; }
        public virtual DbSet<dy_gx_info> dy_gx_info { get; set; }
        public virtual DbSet<dy_gy_zb_info> dy_gy_zb_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<xt_dept>()
                .Property(e => e.dept)
                .IsUnicode(false);

            modelBuilder.Entity<xt_dept>()
                .Property(e => e.lb)
                .IsUnicode(false);

            modelBuilder.Entity<xt_dept>()
                .Property(e => e.pym)
                .IsUnicode(false);

            modelBuilder.Entity<xt_dept>()
                .Property(e => e.deptkey)
                .IsUnicode(false);

            modelBuilder.Entity<xt_dept>()
                .Property(e => e.jbr)
                .IsUnicode(false);

            modelBuilder.Entity<xt_khb>()
                .Property(e => e.khmc)
                .IsUnicode(false);

            modelBuilder.Entity<xt_khb>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<xt_khb>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<xt_khb>()
                .Property(e => e.pym)
                .IsUnicode(false);

            modelBuilder.Entity<xt_khb>()
                .Property(e => e.bank)
                .IsUnicode(false);

            modelBuilder.Entity<xt_khb>()
                .Property(e => e.khqc)
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.rylb)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.gzlb)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.xm)
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.gh)
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.pym)
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.xb)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.zjhm)
                .IsUnicode(false);

            modelBuilder.Entity<xt_ryb>()
                .Property(e => e.mm)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.dydbh)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.kh)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.km)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.cf)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.szi)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.khkh)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.yplb)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.ry_sj)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.ry_gy)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.ry_zb)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.ry_jb)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.ry_yw)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.zx)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.dim)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_yd>()
                .Property(e => e.proofId)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_bh>()
                .Property(e => e.cocode)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_bh>()
                .Property(e => e.sz)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_bh>()
                .Property(e => e.gg)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_bh>()
                .Property(e => e.ghpc)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_bh>()
                .Property(e => e.tcjbr)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_bh>()
                .Property(e => e.jth)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_ybgx>()
                .Property(e => e.cocode)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_ybgx>()
                .Property(e => e.gx)
                .IsUnicode(false);

            modelBuilder.Entity<scgl_ybgx>()
                .Property(e => e.bjmc)
                .IsUnicode(false);

            modelBuilder.Entity<xt_zdcs>()
                .Property(e => e.zdm)
                .IsUnicode(false);

            modelBuilder.Entity<xt_zdcs>()
                .Property(e => e.cs)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gx>()
                .Property(e => e.gxlb)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gx>()
                .Property(e => e.gx)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gx>()
                .Property(e => e.czr)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gx>()
                .Property(e => e.sl)
                .HasPrecision(9, 2);

            modelBuilder.Entity<ypgl_gx>()
                .Property(e => e.dw)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gx>()
                .Property(e => e.dj)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ypgl_gx>()
                .Property(e => e.gj)
                .HasPrecision(9, 4);

            modelBuilder.Entity<ypgl_gx>()
                .Property(e => e.dim)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gxczrback>()
                .Property(e => e.cocode)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gxczrback>()
                .Property(e => e.gx)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gxczrback>()
                .Property(e => e.back)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gyzbjl>()
                .Property(e => e.gg)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gyzbjl>()
                .Property(e => e.ry_gy)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_gyzbjl>()
                .Property(e => e.ry_zb)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_zb>()
                .Property(e => e.ry_zb)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_zb>()
                .Property(e => e.mnsj)
                .HasPrecision(5, 1);

            modelBuilder.Entity<ypgl_zb>()
                .Property(e => e.jx)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_zb>()
                .Property(e => e.bh)
                .IsUnicode(false);

            modelBuilder.Entity<ypgl_zb>()
                .Property(e => e.zx)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gx_info>()
                .Property(e => e.dydbh)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gx_info>()
                .Property(e => e.gx)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gx_info>()
                .Property(e => e.xm)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gx_info>()
                .Property(e => e.proofId)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.dydbh)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.kh)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.km)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.cf)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.szi)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.khkh)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.yplb)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.ry_sj)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.ry_gy)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.ry_zb)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.ry_jb)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.ry_yw)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.zx)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.dim)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.gg)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.gy_name)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.zb_name)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.mnsj)
                .HasPrecision(5, 1);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.jx)
                .IsUnicode(false);

            modelBuilder.Entity<dy_gy_zb_info>()
                .Property(e => e.bh)
                .IsUnicode(false);
        }
    }
}
