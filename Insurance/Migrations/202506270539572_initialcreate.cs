namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        PolicyId = c.Int(nullable: false, identity: true),
                        PolicyName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PolicyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Policies");
        }
    }
}
