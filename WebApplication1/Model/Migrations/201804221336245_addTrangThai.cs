namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTrangThai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SINH_VIEN", "TRANG_THAI", c => c.Boolean());
            AddColumn("dbo.NHAN_VIEN", "TRANG_THAI", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NHAN_VIEN", "TRANG_THAI");
            DropColumn("dbo.SINH_VIEN", "TRANG_THAI");
        }
    }
}
