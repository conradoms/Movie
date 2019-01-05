namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) Values (1, 0, 0, 0, 'Pay as you go')");
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) Values (2, 30, 1, 10, 'Monthly')");
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) Values (3, 90, 3, 15, 'Quarterly')");
            Sql("Insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) Values (4, 300, 12, 30, 'Annualy')");
        }
        
        public override void Down()
        {
        }
    }
}
