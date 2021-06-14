namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_change1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary(maxLength: 512));
            AlterColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary(maxLength: 512));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary(maxLength: 512));
        }
    }
}
