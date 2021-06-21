using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiSpaceService.Migrations
{
    public partial class RenameFacilityAddOnToQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityAddOn");

            migrationBuilder.CreateTable(
                name: "QuantityAddOn",
                columns: table => new
                {
                    QuantityAddOnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberBookingSpaceID = table.Column<int>(nullable: true),
                    AddOnName = table.Column<string>(nullable: true),
                    ActualCost = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    DiscountPercent = table.Column<double>(nullable: false),
                    ReducedCost = table.Column<double>(nullable: false),
                    IsIncludeInInvoice = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityAddOn", x => x.QuantityAddOnID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuantityAddOn");

            migrationBuilder.CreateTable(
                name: "FacilityAddOn",
                columns: table => new
                {
                    FacilityAddOnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualCost = table.Column<double>(nullable: false),
                    AddOnName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    DiscountPercent = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsIncludeInInvoice = table.Column<bool>(nullable: false),
                    MemberBookingSpaceID = table.Column<int>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    ReducedCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityAddOn", x => x.FacilityAddOnID);
                });
        }
    }
}
