using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiSpaceService.Migrations
{
    public partial class AddFacilityBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilityBooking",
                columns: table => new
                {
                    FacilityBookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberBookingSpaceID = table.Column<int>(nullable: true),
                    ClientFacilityID = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    DiscountPercent = table.Column<double>(nullable: false),
                    IsIncludeInInvoice = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityBooking", x => x.FacilityBookingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityBooking");
        }
    }
}
