namespace du_lich_bien_ba_dong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaDong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinTuc",
                c => new
                    {
                        TinTucId = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(nullable: false, maxLength: 100),
                        NgayBatDau = c.DateTime(nullable: false),
                        NgayKetThuc = c.DateTime(nullable: false),
                        LuotXem = c.Int(nullable: false),
                        HinhAnhUrl = c.String(nullable: false),
                        TomTat = c.String(nullable: false, maxLength: 500),
                        BanTin = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.TinTucId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinTuc");
        }
    }
}
