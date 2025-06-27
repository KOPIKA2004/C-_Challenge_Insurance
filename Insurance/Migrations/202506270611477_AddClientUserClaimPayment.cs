namespace Insurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientUserClaimPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimtId = c.Int(nullable: false, identity: true),
                        ClaimName = c.String(),
                        DateField = c.DateTime(nullable: false),
                        ClaimAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        ClientId = c.Int(),
                        PolicyId = c.Int(),
                    })
                .PrimaryKey(t => t.ClaimtId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Policies", t => t.PolicyId)
                .Index(t => t.ClientId)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        ContactInfo = c.String(),
                        PolicyId = c.Int(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Policies", t => t.PolicyId)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Claims", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Claims", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "PolicyId", "dbo.Policies");
            DropIndex("dbo.Payments", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "PolicyId" });
            DropIndex("dbo.Claims", new[] { "PolicyId" });
            DropIndex("dbo.Claims", new[] { "ClientId" });
            DropTable("dbo.Users");
            DropTable("dbo.Payments");
            DropTable("dbo.Clients");
            DropTable("dbo.Claims");
        }
    }
}
