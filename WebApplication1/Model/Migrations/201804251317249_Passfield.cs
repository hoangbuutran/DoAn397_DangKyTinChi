namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Passfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MON_HOC", "TU_CHON", c => c.Boolean());
            AddColumn("dbo.MON_HOC", "NHOM_TU_CHON", c => c.Int());
            DropColumn("dbo.CHUYENNGANH_MONHOC", "TU_CHON");
            DropColumn("dbo.CHUYENNGANH_MONHOC", "NHOM_TU_CHON");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CHUYENNGANH_MONHOC", "NHOM_TU_CHON", c => c.Int());
            AddColumn("dbo.CHUYENNGANH_MONHOC", "TU_CHON", c => c.Boolean());
            DropColumn("dbo.MON_HOC", "NHOM_TU_CHON");
            DropColumn("dbo.MON_HOC", "TU_CHON");
        }
    }
}
