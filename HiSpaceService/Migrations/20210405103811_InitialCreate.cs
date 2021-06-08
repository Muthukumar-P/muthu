using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiSpaceService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: true),
                    EmpCode = table.Column<string>(nullable: true),
                    AttendanceDate = table.Column<DateTime>(nullable: true),
                    InTime = table.Column<TimeSpan>(nullable: true),
                    OutTime = table.Column<TimeSpan>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceID);
                });

            migrationBuilder.CreateTable(
                name: "ChairType",
                columns: table => new
                {
                    ChairTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChairTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChairType", x => x.ChairTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ClientFacility",
                columns: table => new
                {
                    ClientFacilityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: true),
                    ClientLocationID = table.Column<int>(nullable: true),
                    ClientFloorID = table.Column<int>(nullable: true),
                    ClientSpaceFloorPlanID = table.Column<int>(nullable: false),
                    FacilityID = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    IsPaidAmenity = table.Column<bool>(nullable: false),
                    PaidAmenityPrice = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFacility", x => x.ClientFacilityID);
                });

            migrationBuilder.CreateTable(
                name: "ClientFloor",
                columns: table => new
                {
                    ClientFloorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: true),
                    ClientLocationID = table.Column<int>(nullable: true),
                    FloorNumber = table.Column<int>(nullable: true),
                    FloorName = table.Column<string>(nullable: true),
                    FloorPlanFilePath = table.Column<string>(nullable: true),
                    PaidAmenitiesPrice = table.Column<double>(nullable: true),
                    FloorDescription = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFloor", x => x.ClientFloorID);
                });

            migrationBuilder.CreateTable(
                name: "ClientLocation",
                columns: table => new
                {
                    ClientLocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: false),
                    ClientLocationName = table.Column<string>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: true),
                    ClientLocationStatus = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<int>(nullable: true),
                    Pincode = table.Column<int>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    ContactPersonAadhaar = table.Column<string>(nullable: true),
                    ContactPersonPAN = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLocation", x => x.ClientLocationID);
                });

            migrationBuilder.CreateTable(
                name: "ClientMaster",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientName = table.Column<string>(nullable: true),
                    ClientStatus = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    GSTIN = table.Column<string>(nullable: true),
                    PAN = table.Column<string>(nullable: true),
                    UAN = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<int>(nullable: true),
                    Pincode = table.Column<int>(nullable: true),
                    ClientLogo = table.Column<string>(nullable: true),
                    Doc_RCCopy = table.Column<string>(nullable: true),
                    Doc_PANCopy = table.Column<string>(nullable: true),
                    Doc_GSTCopy = table.Column<string>(nullable: true),
                    Doc_MembershipAgreementCopy = table.Column<string>(nullable: true),
                    Doc_ContactPersonAadhaar = table.Column<string>(nullable: true),
                    Doc_ContactPersonPAN = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true),
                    ClientNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PrimaryContactName = table.Column<string>(nullable: true),
                    PrimaryContactNumber = table.Column<string>(nullable: true),
                    PrimaryContactEmail = table.Column<string>(nullable: true),
                    ClientUsername = table.Column<string>(nullable: true),
                    ClientPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMaster", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "ClientMembershipPlan",
                columns: table => new
                {
                    ClientMembershipPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: true),
                    MembershipName = table.Column<string>(nullable: true),
                    MembershipDuration = table.Column<int>(nullable: true),
                    MembershipDurationType = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    RenewalAlertDays = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsRecommented = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMembershipPlan", x => x.ClientMembershipPlanID);
                });

            migrationBuilder.CreateTable(
                name: "ClientMembershipPlanHistory",
                columns: table => new
                {
                    ClientMembershipPlanHistoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientMembershipPlanID = table.Column<int>(nullable: true),
                    ClientID = table.Column<int>(nullable: true),
                    MembershipName = table.Column<string>(nullable: true),
                    MembershipDuration = table.Column<int>(nullable: true),
                    MembershipDurationType = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMembershipPlanHistory", x => x.ClientMembershipPlanHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "ClientSpaceAvailableTime",
                columns: table => new
                {
                    ClientSpaceAvailableTimeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: true),
                    ClientFloorID = table.Column<int>(nullable: true),
                    ClientSpaceFloorPlanID = table.Column<int>(nullable: true),
                    Is24Hours = table.Column<bool>(nullable: false),
                    MonToFriDay = table.Column<bool>(nullable: false),
                    StartHours = table.Column<string>(nullable: true),
                    EndHours = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSpaceAvailableTime", x => x.ClientSpaceAvailableTimeID);
                });

            migrationBuilder.CreateTable(
                name: "ClientSpaceSeat",
                columns: table => new
                {
                    ClientSpaceSeatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientSpaceFloorPlanID = table.Column<int>(nullable: false),
                    SeatXCoord = table.Column<int>(nullable: false),
                    SeatYCoord = table.Column<int>(nullable: false),
                    SeatDescription = table.Column<string>(nullable: true),
                    SeatPrice = table.Column<double>(nullable: true),
                    SeatStatus = table.Column<string>(nullable: true),
                    OccupiedBy = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true),
                    MemberID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSpaceSeat", x => x.ClientSpaceSeatID);
                });

            migrationBuilder.CreateTable(
                name: "ClientWorkSpaceFloorPlan",
                columns: table => new
                {
                    ClientSpaceFloorPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: true),
                    ClientLocationID = table.Column<int>(nullable: true),
                    SpaceName = table.Column<string>(nullable: true),
                    WSpaceTypeID = table.Column<int>(nullable: true),
                    ChairTypeID = table.Column<int>(nullable: true),
                    ClientFloorID = table.Column<int>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    OccupiedBy = table.Column<int>(nullable: true),
                    TotalViews = table.Column<int>(nullable: true),
                    IsEnable = table.Column<bool>(nullable: false),
                    FloorPlanFilePath = table.Column<string>(nullable: true),
                    ScaleMetricID = table.Column<int>(nullable: true),
                    FloorLength = table.Column<double>(nullable: true),
                    FloorBreadth = table.Column<double>(nullable: true),
                    NumberOfRows = table.Column<int>(nullable: true),
                    NumberOfColumns = table.Column<int>(nullable: true),
                    SeatSize = table.Column<double>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true),
                    Verification = table.Column<string>(nullable: true),
                    SpaceDescription = table.Column<string>(nullable: true),
                    Is24 = table.Column<bool>(nullable: true),
                    SunAvail = table.Column<bool>(nullable: true),
                    SunOpen = table.Column<TimeSpan>(nullable: true),
                    SunClose = table.Column<TimeSpan>(nullable: true),
                    MonAvail = table.Column<bool>(nullable: true),
                    MonOpen = table.Column<TimeSpan>(nullable: true),
                    MonClose = table.Column<TimeSpan>(nullable: true),
                    TueAvail = table.Column<bool>(nullable: true),
                    TueOpen = table.Column<TimeSpan>(nullable: true),
                    TueClose = table.Column<TimeSpan>(nullable: true),
                    WedAvail = table.Column<bool>(nullable: true),
                    WedOpen = table.Column<TimeSpan>(nullable: true),
                    WedClose = table.Column<TimeSpan>(nullable: true),
                    ThuAvail = table.Column<bool>(nullable: true),
                    ThuOpen = table.Column<TimeSpan>(nullable: true),
                    ThuClose = table.Column<TimeSpan>(nullable: true),
                    FriAvail = table.Column<bool>(nullable: true),
                    FriOpen = table.Column<TimeSpan>(nullable: true),
                    FriClose = table.Column<TimeSpan>(nullable: true),
                    SatAvail = table.Column<bool>(nullable: true),
                    SatOpen = table.Column<TimeSpan>(nullable: true),
                    SatClose = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientWorkSpaceFloorPlan", x => x.ClientSpaceFloorPlanID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMaster",
                columns: table => new
                {
                    EmpID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: false),
                    EmpCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    PAN = table.Column<string>(nullable: true),
                    Identification = table.Column<string>(nullable: true),
                    DOJ = table.Column<DateTime>(nullable: true),
                    DOR = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMaster", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "FacilityMaster",
                columns: table => new
                {
                    FacilityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacilityName = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityMaster", x => x.FacilityID);
                });

            migrationBuilder.CreateTable(
                name: "HolidayMaster",
                columns: table => new
                {
                    HolidayID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: false),
                    HolidayDate = table.Column<DateTime>(nullable: false),
                    HolidayDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayMaster", x => x.HolidayID);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    LeadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: false),
                    LeadGenerationCode = table.Column<string>(nullable: true),
                    LeadName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Pincode = table.Column<int>(nullable: true),
                    Aadhaar = table.Column<string>(nullable: true),
                    SpaceType = table.Column<string>(nullable: true),
                    TotalEmployee = table.Column<int>(nullable: true),
                    TotalSeat = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.LeadID);
                });                

            migrationBuilder.CreateTable(
                name: "MemberMaster",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ClientMembershipPlanID = table.Column<int>(nullable: true),
                    MembershipStartedDate = table.Column<DateTime>(nullable: true),
                    MembershipExpiryDate = table.Column<DateTime>(nullable: true),
                    RenewalAlertDate = table.Column<DateTime>(nullable: true),
                    MembershipPriceOnDate = table.Column<double>(nullable: true),
                    RenewalAlertDays = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true),
                    ClientID = table.Column<int>(nullable: true),
                    GSTIN = table.Column<string>(nullable: true),
                    PAN = table.Column<string>(nullable: true),
                    UAN = table.Column<string>(nullable: true),
                    Fax = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Pincode = table.Column<int>(nullable: true),
                    DepositeRefundable = table.Column<float>(nullable: true),
                    DepositeNonRefundable = table.Column<float>(nullable: true),
                    DiscountPercent = table.Column<float>(nullable: true),
                    DiscountedPrice = table.Column<float>(nullable: true),
                    MemberStatus = table.Column<bool>(nullable: false),
                    Doc_ContactPersonAadhaar = table.Column<string>(nullable: true),
                    Doc_ContactPersonPAN = table.Column<string>(nullable: true),
                    Doc_RCCopy = table.Column<string>(nullable: true),
                    PrimaryContactName = table.Column<string>(nullable: true),
                    PrimaryContactNumber = table.Column<string>(nullable: true),
                    PrimaryContactEmail = table.Column<string>(nullable: true),
                    MemberUsername = table.Column<string>(nullable: true),
                    MemberPassword = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberMaster", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "MembershipHistory",
                columns: table => new
                {
                    MembershipHistoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientMembershipPlanID = table.Column<int>(nullable: true),
                    MemberID = table.Column<int>(nullable: true),
                    StartedDate = table.Column<DateTime>(nullable: true),
                    ExpiredDate = table.Column<DateTime>(nullable: true),
                    RenewalDate = table.Column<DateTime>(nullable: true),
                    PriceOnDate = table.Column<double>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipHistory", x => x.MembershipHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "MyCard",
                columns: table => new
                {
                    CardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: true),
                    MemberID = table.Column<int>(nullable: true),
                    ClientSpaceFloorPlanID = table.Column<int>(nullable: true),
                    SpaceName = table.Column<string>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    ClientSpaceSeatID = table.Column<int>(nullable: true),
                    IsFullSpace = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCard", x => x.CardID);
                });

            migrationBuilder.CreateTable(
                name: "ScaleMetric",
                columns: table => new
                {
                    ScaleMetricID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScaleMetricName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScaleMetric", x => x.ScaleMetricID);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    MemberID = table.Column<int>(nullable: true),
                    ClientID = table.Column<int>(nullable: true),
                    ClientLocationID = table.Column<int>(nullable: true),
                    LastLoginDateTime = table.Column<DateTime>(nullable: true),
                    LoginCount = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<int>(nullable: true),
                    ModifyDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "WSpaceType",
                columns: table => new
                {
                    WSpaceTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WSpaceTypeName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WSpaceType", x => x.WSpaceTypeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "ChairType");

            migrationBuilder.DropTable(
                name: "ClientFacility");

            migrationBuilder.DropTable(
                name: "ClientFloor");

            migrationBuilder.DropTable(
                name: "ClientLocation");

            migrationBuilder.DropTable(
                name: "ClientMaster");

            migrationBuilder.DropTable(
                name: "ClientMembershipPlan");

            migrationBuilder.DropTable(
                name: "ClientMembershipPlanHistory");

            migrationBuilder.DropTable(
                name: "ClientSpaceAvailableTime");

            migrationBuilder.DropTable(
                name: "ClientSpaceSeat");

            migrationBuilder.DropTable(
                name: "ClientWorkSpaceFloorPlan");

            migrationBuilder.DropTable(
                name: "EmployeeMaster");

            migrationBuilder.DropTable(
                name: "FacilityMaster");

            migrationBuilder.DropTable(
                name: "HolidayMaster");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "MemberMaster");

            migrationBuilder.DropTable(
                name: "MembershipHistory");

            migrationBuilder.DropTable(
                name: "MyCard");

            migrationBuilder.DropTable(
                name: "ScaleMetric");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "WSpaceType");
        }
    }
}
