namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CHUYEN_NGANH",
                c => new
                    {
                        ID_CHUYEN_NGANH = c.Int(nullable: false, identity: true),
                        TEN_CHUYEN_NGANH = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID_CHUYEN_NGANH);
            
            CreateTable(
                "dbo.CHUYENNGANH_MONHOC",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ID_MONHOC = c.Int(),
                        ID_CHUYENNGANH = c.Int(),
                        TU_CHON = c.Boolean(),
                        NHOM_TU_CHON = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MON_HOC", t => t.ID_MONHOC)
                .ForeignKey("dbo.CHUYEN_NGANH", t => t.ID_CHUYENNGANH)
                .Index(t => t.ID_MONHOC)
                .Index(t => t.ID_CHUYENNGANH);
            
            CreateTable(
                "dbo.MON_HOC",
                c => new
                    {
                        ID_MON_HOC = c.Int(nullable: false, identity: true),
                        MA_MON_HOC = c.String(nullable: false, maxLength: 500, fixedLength: true, unicode: false),
                        TEN_MON_HOC = c.String(maxLength: 500),
                        SO_CHI = c.Int(),
                        LOAI_DVHT = c.String(maxLength: 500),
                        LOAI_HINH = c.String(maxLength: 500),
                        MON_TIEN_QUYET = c.String(maxLength: 500),
                        MON_SONG_HANH = c.String(maxLength: 500),
                        MO_TA = c.String(storeType: "ntext"),
                        TRANG_THAI = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID_MON_HOC);
            
            CreateTable(
                "dbo.CT_PHIEU_DANG_KY",
                c => new
                    {
                        ID_CT_PHIEU_DANG_KY = c.Int(nullable: false, identity: true),
                        ID_PHIEU_DANG_KY = c.Int(),
                        ID_MON_HOC = c.Int(),
                    })
                .PrimaryKey(t => t.ID_CT_PHIEU_DANG_KY)
                .ForeignKey("dbo.MON_HOC", t => t.ID_MON_HOC)
                .ForeignKey("dbo.PHIEU_DANG_KY", t => t.ID_PHIEU_DANG_KY)
                .Index(t => t.ID_PHIEU_DANG_KY)
                .Index(t => t.ID_MON_HOC);
            
            CreateTable(
                "dbo.PHIEU_DANG_KY",
                c => new
                    {
                        ID_PHIEU_DANG_KY = c.Int(nullable: false, identity: true),
                        ID_SINHVIEN = c.Int(),
                        ID_HOC_KY = c.Int(),
                        ID_NAM_HOC = c.Int(),
                        TONG_SO_TIN_CHI = c.Int(),
                    })
                .PrimaryKey(t => t.ID_PHIEU_DANG_KY)
                .ForeignKey("dbo.HOC_KY", t => t.ID_HOC_KY)
                .ForeignKey("dbo.NAM_HOC", t => t.ID_NAM_HOC)
                .ForeignKey("dbo.SINH_VIEN", t => t.ID_SINHVIEN)
                .Index(t => t.ID_SINHVIEN)
                .Index(t => t.ID_HOC_KY)
                .Index(t => t.ID_NAM_HOC);
            
            CreateTable(
                "dbo.HOC_KY",
                c => new
                    {
                        ID_HOC_KY = c.Int(nullable: false, identity: true),
                        TEN_HOC_KY = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID_HOC_KY);
            
            CreateTable(
                "dbo.NAM_HOC",
                c => new
                    {
                        ID_NAM_HOC = c.Int(nullable: false, identity: true),
                        TEN_NAM_HOC = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        TRANGTHAI = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID_NAM_HOC);
            
            CreateTable(
                "dbo.SINH_VIEN",
                c => new
                    {
                        ID_SINHVIEN = c.Int(nullable: false, identity: true),
                        MA_SINH_VIEN = c.String(nullable: false, maxLength: 500, fixedLength: true, unicode: false),
                        TEN_SINH_VIEN = c.String(maxLength: 500),
                        NGAY_SINH = c.DateTime(),
                        CMND = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        DIEN_THOAI = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        DIA_CHI = c.String(maxLength: 900),
                        EMAIL = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        ID_TAI_KHOAN = c.Int(),
                        ID_CHUYEN_NGANH = c.Int(),
                    })
                .PrimaryKey(t => t.ID_SINHVIEN)
                .ForeignKey("dbo.CHUYEN_NGANH", t => t.ID_CHUYEN_NGANH)
                .ForeignKey("dbo.TAIKHOAN", t => t.ID_TAI_KHOAN)
                .Index(t => t.ID_TAI_KHOAN)
                .Index(t => t.ID_CHUYEN_NGANH);
            
            CreateTable(
                "dbo.TAIKHOAN",
                c => new
                    {
                        ID_TAI_KHOAN = c.Int(nullable: false, identity: true),
                        USERNAME = c.String(maxLength: 500),
                        PASS = c.String(maxLength: 500),
                        ID_QUYEN = c.Int(),
                    })
                .PrimaryKey(t => t.ID_TAI_KHOAN)
                .ForeignKey("dbo.QUYEN", t => t.ID_QUYEN)
                .Index(t => t.ID_QUYEN);
            
            CreateTable(
                "dbo.NHAN_VIEN",
                c => new
                    {
                        ID_NHANVIEN = c.Int(nullable: false, identity: true),
                        TEN_NHANVIEN = c.String(maxLength: 50),
                        NGAY_SINH = c.DateTime(storeType: "date"),
                        DIEN_THOAI = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        DIA_CHI = c.String(maxLength: 900),
                        EMAIL = c.String(maxLength: 500, fixedLength: true, unicode: false),
                        ID_TAI_KHOAN = c.Int(),
                    })
                .PrimaryKey(t => t.ID_NHANVIEN)
                .ForeignKey("dbo.TAIKHOAN", t => t.ID_TAI_KHOAN)
                .Index(t => t.ID_TAI_KHOAN);
            
            CreateTable(
                "dbo.QUYEN",
                c => new
                    {
                        ID_QUYEN = c.Int(nullable: false, identity: true),
                        TEN_QUYEN = c.String(maxLength: 500),
                        MO_TA = c.String(storeType: "ntext"),
                        TRANG_THAI = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID_QUYEN);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CHUYENNGANH_MONHOC", "ID_CHUYENNGANH", "dbo.CHUYEN_NGANH");
            DropForeignKey("dbo.SINH_VIEN", "ID_TAI_KHOAN", "dbo.TAIKHOAN");
            DropForeignKey("dbo.TAIKHOAN", "ID_QUYEN", "dbo.QUYEN");
            DropForeignKey("dbo.NHAN_VIEN", "ID_TAI_KHOAN", "dbo.TAIKHOAN");
            DropForeignKey("dbo.PHIEU_DANG_KY", "ID_SINHVIEN", "dbo.SINH_VIEN");
            DropForeignKey("dbo.SINH_VIEN", "ID_CHUYEN_NGANH", "dbo.CHUYEN_NGANH");
            DropForeignKey("dbo.PHIEU_DANG_KY", "ID_NAM_HOC", "dbo.NAM_HOC");
            DropForeignKey("dbo.PHIEU_DANG_KY", "ID_HOC_KY", "dbo.HOC_KY");
            DropForeignKey("dbo.CT_PHIEU_DANG_KY", "ID_PHIEU_DANG_KY", "dbo.PHIEU_DANG_KY");
            DropForeignKey("dbo.CT_PHIEU_DANG_KY", "ID_MON_HOC", "dbo.MON_HOC");
            DropForeignKey("dbo.CHUYENNGANH_MONHOC", "ID_MONHOC", "dbo.MON_HOC");
            DropIndex("dbo.NHAN_VIEN", new[] { "ID_TAI_KHOAN" });
            DropIndex("dbo.TAIKHOAN", new[] { "ID_QUYEN" });
            DropIndex("dbo.SINH_VIEN", new[] { "ID_CHUYEN_NGANH" });
            DropIndex("dbo.SINH_VIEN", new[] { "ID_TAI_KHOAN" });
            DropIndex("dbo.PHIEU_DANG_KY", new[] { "ID_NAM_HOC" });
            DropIndex("dbo.PHIEU_DANG_KY", new[] { "ID_HOC_KY" });
            DropIndex("dbo.PHIEU_DANG_KY", new[] { "ID_SINHVIEN" });
            DropIndex("dbo.CT_PHIEU_DANG_KY", new[] { "ID_MON_HOC" });
            DropIndex("dbo.CT_PHIEU_DANG_KY", new[] { "ID_PHIEU_DANG_KY" });
            DropIndex("dbo.CHUYENNGANH_MONHOC", new[] { "ID_CHUYENNGANH" });
            DropIndex("dbo.CHUYENNGANH_MONHOC", new[] { "ID_MONHOC" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.QUYEN");
            DropTable("dbo.NHAN_VIEN");
            DropTable("dbo.TAIKHOAN");
            DropTable("dbo.SINH_VIEN");
            DropTable("dbo.NAM_HOC");
            DropTable("dbo.HOC_KY");
            DropTable("dbo.PHIEU_DANG_KY");
            DropTable("dbo.CT_PHIEU_DANG_KY");
            DropTable("dbo.MON_HOC");
            DropTable("dbo.CHUYENNGANH_MONHOC");
            DropTable("dbo.CHUYEN_NGANH");
        }
    }
}
