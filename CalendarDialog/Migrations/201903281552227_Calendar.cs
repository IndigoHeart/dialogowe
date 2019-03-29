namespace CalendarDialog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calendar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        eventName = c.String(),
                        dateOfEvent = c.DateTime(nullable: false),
                        startHour = c.String(),
                        endHour = c.String(),
                        localization = c.String(),
                        eventNature = c.String(),
                        row = c.Int(nullable: false),
                        column = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewEvents");
        }
    }
}
