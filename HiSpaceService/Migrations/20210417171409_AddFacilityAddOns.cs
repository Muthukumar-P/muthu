using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiSpaceService.Migrations
{
    public partial class AddFacilityAddOns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilityAddOn",
                columns: table => new
                {
                    FacilityAddOnID = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_FacilityAddOn", x => x.FacilityAddOnID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberBookingSpaceSeat_MemberBookingSpaceID",
                table: "MemberBookingSpaceSeat",
                column: "MemberBookingSpaceID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityBooking_ClientFacilityID",
                table: "FacilityBooking",
                column: "ClientFacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityBooking_MemberBookingSpaceID",
                table: "FacilityBooking",
                column: "MemberBookingSpaceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityAddOn");

            migrationBuilder.DropIndex(
                name: "IX_MemberBookingSpaceSeat_MemberBookingSpaceID",
                table: "MemberBookingSpaceSeat");

            migrationBuilder.DropIndex(
                name: "IX_FacilityBooking_ClientFacilityID",
                table: "FacilityBooking");

            migrationBuilder.DropIndex(
                name: "IX_FacilityBooking_MemberBookingSpaceID",
                table: "FacilityBooking");
        }
    }
}
