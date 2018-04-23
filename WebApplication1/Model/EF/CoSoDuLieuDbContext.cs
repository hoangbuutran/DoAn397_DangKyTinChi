namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CoSoDuLieuDbContext : DbContext
    {
        public CoSoDuLieuDbContext()
            : base("name=CoSoDuLieuDbContext1")
        {
        }

        public virtual DbSet<CHUYEN_NGANH> CHUYEN_NGANH { get; set; }
        public virtual DbSet<CHUYENNGANH_MONHOC> CHUYENNGANH_MONHOC { get; set; }
        public virtual DbSet<CT_PHIEU_DANG_KY> CT_PHIEU_DANG_KY { get; set; }
        public virtual DbSet<HOC_KY> HOC_KY { get; set; }
        public virtual DbSet<MON_HOC> MON_HOC { get; set; }
        public virtual DbSet<NAM_HOC> NAM_HOC { get; set; }
        public virtual DbSet<NHAN_VIEN> NHAN_VIEN { get; set; }
        public virtual DbSet<PHIEU_DANG_KY> PHIEU_DANG_KY { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<SINH_VIEN> SINH_VIEN { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUYEN_NGANH>()
                .HasMany(e => e.CHUYENNGANH_MONHOC)
                .WithOptional(e => e.CHUYEN_NGANH)
                .HasForeignKey(e => e.ID_CHUYENNGANH);

            modelBuilder.Entity<MON_HOC>()
                .Property(e => e.MA_MON_HOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MON_HOC>()
                .HasMany(e => e.CHUYENNGANH_MONHOC)
                .WithOptional(e => e.MON_HOC)
                .HasForeignKey(e => e.ID_MONHOC);

            modelBuilder.Entity<NAM_HOC>()
                .Property(e => e.TEN_NAM_HOC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.DIEN_THOAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.EMAIL)
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

        //public System.Data.Entity.DbSet<WebApplication1.Common.DoiMatKhauModel> DoiMatKhauModels { get; set; }

        //public System.Data.Entity.DbSet<WebApplication1.Common.DoiMatKhauModel> DoiMatKhauModels { get; set; }
    }
}
