namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoSoDuLieuDbContext : DbContext
    {
        public CoSoDuLieuDbContext()
            : base("name=CoSoDuLieuDbContext")
        {
        }

        public virtual DbSet<CHUONG_TRINH_HOC> CHUONG_TRINH_HOC { get; set; }
        public virtual DbSet<CHUYEN_NGANH> CHUYEN_NGANH { get; set; }
        public virtual DbSet<CT_PHIEU_DANG_KY> CT_PHIEU_DANG_KY { get; set; }
        public virtual DbSet<HOC_KY> HOC_KY { get; set; }        
        public virtual DbSet<MON_HOC> MON_HOC { get; set; }
        public virtual DbSet<NAM_HOC> NAM_HOC { get; set; }
        public virtual DbSet<PHIEU_DANG_KY> PHIEU_DANG_KY { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<SINH_VIEN> SINH_VIEN { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MON_HOC>()
                .Property(e => e.MA_MON_HOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NAM_HOC>()
                .Property(e => e.TEN_NAM_HOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SINH_VIEN>()
                .Property(e => e.MA_SINH_VIEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SINH_VIEN>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SINH_VIEN>()
                .Property(e => e.DIEN_THOAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SINH_VIEN>()
                .Property(e => e.EMAIL)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
