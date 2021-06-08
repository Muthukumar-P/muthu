using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiSpaceService.Migrations
{
    public partial class AddInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeatCost = table.Column<double>(nullable: true),
                    SpaceCost = table.Column<double>(nullable: true),
                    FacilitiesTotal = table.Column<double>(nullable: true),
                    GST = table.Column<double>(nullable: true),
                    TotalCost = table.Column<double>(nullable: true),
                    MemberBookingSpaceID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
