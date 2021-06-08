namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_change_name_convention : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drafts", "ReceiverMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Drafts", "DraftContent", c => c.String());
            AddColumn("dbo.Drafts", "DraftDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Drafts", "Mail");
            DropColumn("dbo.Drafts", "MessageContent");
            DropColumn("dbo.Drafts", "MessageDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drafts", "MessageDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Drafts", "MessageContent", c => c.String());
            AddColumn("dbo.Drafts", "Mail", c => c.String(maxLength: 50));
            DropColumn("dbo.Drafts", "DraftDate");
            DropColumn("dbo.Drafts", "DraftContent");
            DropColumn("dbo.Drafts", "ReceiverMail");
        }
    }
}
