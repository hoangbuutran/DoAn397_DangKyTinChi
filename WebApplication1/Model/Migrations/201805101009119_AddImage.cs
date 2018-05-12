namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SINH_VIEN", "Image", c => c.String(maxLength: 800));
            AddColumn("dbo.NHAN_VIEN", "Image", c => c.String(maxLength: 800));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NHAN_VIEN", "Image");
            DropColumn("dbo.SINH_VIEN", "Image");
        }
    }
}
