using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiSpaceService.Migrations
{
    public partial class AddSpaceSeatBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberBookingSpace",
                columns: table => new
                {
                    MemberBookingSpaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: true),
                    ClientID = table.Column<int>(nullable: true),
                    ClientLocationID = table.Column<int>(nullable: true),
                    ClientSpaceFloorPlanID = table.Column<int>(nullable: true),
                    SpacePrice = table.Column<double>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: true),
                    DurationType = table.Column<string>(nullable: true),
                    DurationInterval = table.Column<int>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: true),
                    SeatPrice = table.Column<double>(nullable: true),
                    BookingStatus = table.Column<string>(nullable: true),
                    IsInvoiceCreated = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberBookingSpace", x => x.MemberBookingSpaceID);
                });

            migrationBuilder.CreateTable(
                name: "MemberBookingSpaceSeat",
                columns: table => new
                {
                    MemberBookingSpaceSeatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberBookingSpaceID = table.Column<int>(nullable: true),
                    ClientSpaceSeatID = table.Column<int>(nullable: true),
                    SeatPrice = table.Column<double>(nullable: true),
                    SeatStatus = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true),
                    FromDateTime = table.Column<DateTime>(nullable: true),
                    ToDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberBookingSpaceSeat", x => x.MemberBookingSpaceSeatID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {        
            migrationBuilder.DropTable(
                name: "MemberBookingSpace");

            migrationBuilder.DropTable(
                name: "MemberBookingSpaceSeat");
        }
    }
}
