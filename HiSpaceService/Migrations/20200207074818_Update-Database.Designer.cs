﻿// <auto-generated />
using System;
using HiSpaceService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HiSpaceService.Migrations
{
    [DbContext(typeof(HiSpaceContext))]
    [Migration("20200207074818_Update-Database")]
    partial class UpdateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HiSpaceModels.Attendance", b =>
                {
                    b.Property<int>("AttendanceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AttendanceDate");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<string>("EmpCode");

                    b.Property<TimeSpan?>("InTime");

                    b.Property<int?>("MemberID");

                    b.Property<TimeSpan?>("OutTime");

                    b.HasKey("AttendanceID");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("HiSpaceModels.ChairType", b =>
                {
                    b.Property<int>("ChairTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChairTypeName");

                    b.HasKey("ChairTypeID");

                    b.ToTable("ChairType");
                });

            modelBuilder.Entity("HiSpaceModels.ClientFacility", b =>
                {
                    b.Property<int>("ClientFacilityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<int?>("ClientFloorID");

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientLocationID");

                    b.Property<int>("ClientSpaceFloorPlanID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<int>("FacilityID");

                    b.Property<bool>("IsPaidAmenity");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<double>("PaidAmenityPrice");

                    b.HasKey("ClientFacilityID");

                    b.ToTable("ClientFacility");
                });

            modelBuilder.Entity("HiSpaceModels.ClientFloor", b =>
                {
                    b.Property<int>("ClientFloorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientLocationID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<string>("FloorDescription");

                    b.Property<string>("FloorName");

                    b.Property<int?>("FloorNumber");

                    b.Property<string>("FloorPlanFilePath");

                    b.Property<double?>("PaidAmenitiesPrice");

                    b.HasKey("ClientFloorID");

                    b.ToTable("ClientFloor");
                });

            modelBuilder.Entity("HiSpaceModels.ClientLocation", b =>
                {
                    b.Property<int>("ClientLocationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<int>("ClientID");

                    b.Property<string>("ClientLocationName");

                    b.Property<bool>("ClientLocationStatus");

                    b.Property<string>("ContactPersonAadhaar");

                    b.Property<string>("ContactPersonName");

                    b.Property<string>("ContactPersonPAN");

                    b.Property<string>("Country");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<string>("Email");

                    b.Property<int?>("Fax");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<int?>("NumberOfSeats");

                    b.Property<int?>("Pincode");

                    b.Property<string>("State");

                    b.HasKey("ClientLocationID");

                    b.ToTable("ClientLocation");
                });

            modelBuilder.Entity("HiSpaceModels.ClientMaster", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ClientLogo");

                    b.Property<string>("ClientName");

                    b.Property<string>("ClientNumber");

                    b.Property<string>("ClientPassword");

                    b.Property<string>("ClientStatus");

                    b.Property<string>("ClientUsername");

                    b.Property<string>("Country");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<string>("Doc_ContactPersonAadhaar");

                    b.Property<string>("Doc_ContactPersonPAN");

                    b.Property<string>("Doc_GSTCopy");

                    b.Property<string>("Doc_MembershipAgreementCopy");

                    b.Property<string>("Doc_PANCopy");

                    b.Property<string>("Doc_RCCopy");

                    b.Property<string>("Email");

                    b.Property<int?>("Fax");

                    b.Property<string>("GSTIN");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<string>("PAN");

                    b.Property<int?>("Pincode");

                    b.Property<string>("PrimaryContactEmail");

                    b.Property<string>("PrimaryContactName");

                    b.Property<string>("PrimaryContactNumber");

                    b.Property<string>("State");

                    b.Property<string>("UAN");

                    b.HasKey("ClientID");

                    b.ToTable("ClientMaster");
                });

            modelBuilder.Entity("HiSpaceModels.ClientMembershipPlan", b =>
                {
                    b.Property<int>("ClientMembershipPlanID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsActive");

                    b.Property<bool?>("IsRecommented");

                    b.Property<int?>("MembershipDuration");

                    b.Property<string>("MembershipDurationType");

                    b.Property<string>("MembershipName");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<double?>("Price");

                    b.Property<int?>("RenewalAlertDays");

                    b.HasKey("ClientMembershipPlanID");

                    b.ToTable("ClientMembershipPlan");
                });

            modelBuilder.Entity("HiSpaceModels.ClientMembershipPlanHistory", b =>
                {
                    b.Property<int>("ClientMembershipPlanHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientMembershipPlanID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<int?>("MembershipDuration");

                    b.Property<string>("MembershipDurationType");

                    b.Property<string>("MembershipName");

                    b.Property<double?>("Price");

                    b.HasKey("ClientMembershipPlanHistoryID");

                    b.ToTable("ClientMembershipPlanHistory");
                });

            modelBuilder.Entity("HiSpaceModels.ClientSpaceAvailableTime", b =>
                {
                    b.Property<int>("ClientSpaceAvailableTimeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientFloorID");

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientSpaceFloorPlanID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("EndHours");

                    b.Property<bool>("Is24Hours");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<bool>("MonToFriDay");

                    b.Property<string>("StartHours");

                    b.HasKey("ClientSpaceAvailableTimeID");

                    b.ToTable("ClientSpaceAvailableTime");
                });

            modelBuilder.Entity("HiSpaceModels.ClientSpaceSeat", b =>
                {
                    b.Property<int>("ClientSpaceSeatID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientSpaceFloorPlanID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<int?>("MemberID");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<int?>("OccupiedBy");

                    b.Property<string>("SeatDescription");

                    b.Property<double?>("SeatPrice");

                    b.Property<string>("SeatStatus");

                    b.Property<int>("SeatXCoord");

                    b.Property<int>("SeatYCoord");

                    b.HasKey("ClientSpaceSeatID");

                    b.ToTable("ClientSpaceSeat");
                });

            modelBuilder.Entity("HiSpaceModels.ClientWorkSpaceFloorPlan", b =>
                {
                    b.Property<int>("ClientSpaceFloorPlanID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChairTypeID");

                    b.Property<int?>("ClientFloorID");

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientLocationID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<double?>("FloorBreadth");

                    b.Property<double?>("FloorLength");

                    b.Property<string>("FloorPlanFilePath");

                    b.Property<bool?>("FriAvail");

                    b.Property<TimeSpan?>("FriClose");

                    b.Property<TimeSpan?>("FriOpen");

                    b.Property<bool?>("Is24");

                    b.Property<bool>("IsEnable");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<bool?>("MonAvail");

                    b.Property<TimeSpan?>("MonClose");

                    b.Property<TimeSpan?>("MonOpen");

                    b.Property<int?>("NumberOfColumns");

                    b.Property<int?>("NumberOfRows");

                    b.Property<int?>("NumberOfSeats");

                    b.Property<int?>("OccupiedBy");

                    b.Property<double?>("Price");

                    b.Property<bool?>("SatAvail");

                    b.Property<TimeSpan?>("SatClose");

                    b.Property<TimeSpan?>("SatOpen");

                    b.Property<int?>("ScaleMetricID");

                    b.Property<double?>("SeatSize");

                    b.Property<string>("SpaceDescription");

                    b.Property<string>("SpaceName");

                    b.Property<string>("Status");

                    b.Property<bool?>("SunAvail");

                    b.Property<TimeSpan?>("SunClose");

                    b.Property<TimeSpan?>("SunOpen");

                    b.Property<bool?>("ThuAvail");

                    b.Property<TimeSpan?>("ThuClose");

                    b.Property<TimeSpan?>("ThuOpen");

                    b.Property<int?>("TotalViews");

                    b.Property<bool?>("TueAvail");

                    b.Property<TimeSpan?>("TueClose");

                    b.Property<TimeSpan?>("TueOpen");

                    b.Property<string>("Verification");

                    b.Property<int?>("WSpaceTypeID");

                    b.Property<bool?>("WedAvail");

                    b.Property<TimeSpan?>("WedClose");

                    b.Property<TimeSpan?>("WedOpen");

                    b.HasKey("ClientSpaceFloorPlanID");

                    b.ToTable("ClientWorkSpaceFloorPlan");
                });

            modelBuilder.Entity("HiSpaceModels.EmployeeMaster", b =>
                {
                    b.Property<int>("EmpID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<DateTime?>("DOJ");

                    b.Property<DateTime?>("DOR");

                    b.Property<string>("Designation");

                    b.Property<string>("EmpCode");

                    b.Property<string>("Identification");

                    b.Property<int>("MemberID");

                    b.Property<DateTime?>("ModifiedDateTime");

                    b.Property<int?>("ModifyBy");

                    b.Property<string>("Name");

                    b.Property<string>("PAN");

                    b.HasKey("EmpID");

                    b.ToTable("EmployeeMaster");
                });

            modelBuilder.Entity("HiSpaceModels.FacilityMaster", b =>
                {
                    b.Property<int>("FacilityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<string>("FacilityName");

                    b.HasKey("FacilityID");

                    b.ToTable("FacilityMaster");
                });

            modelBuilder.Entity("HiSpaceModels.HolidayMaster", b =>
                {
                    b.Property<int>("HolidayID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientID");

                    b.Property<DateTime>("HolidayDate");

                    b.Property<string>("HolidayDetails");

                    b.HasKey("HolidayID");

                    b.ToTable("HolidayMaster");
                });

            modelBuilder.Entity("HiSpaceModels.Lead", b =>
                {
                    b.Property<int>("LeadID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aadhaar");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<int>("ClientID");

                    b.Property<string>("Country");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<int>("LeadGenerationCode");

                    b.Property<string>("LeadName");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<string>("Phone");

                    b.Property<int?>("Pincode");

                    b.Property<string>("SpaceType");

                    b.Property<string>("State");

                    b.Property<int?>("TotalEmployee");

                    b.Property<int?>("TotalSeat");

                    b.HasKey("LeadID");

                    b.ToTable("Lead");
                });

            modelBuilder.Entity("HiSpaceModels.MemberBookingSpace", b =>
                {
                    b.Property<int>("MemberBookingSpaceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingStatus");

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientLocationID");

                    b.Property<int?>("ClientSpaceFloorPlanID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<int?>("MemberID");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<double?>("SpacePrice");

                    b.HasKey("MemberBookingSpaceID");

                    b.ToTable("MemberBookingSpace");
                });

            modelBuilder.Entity("HiSpaceModels.MemberBookingSpaceSeat", b =>
                {
                    b.Property<int>("MemberBookingSpaceSeatID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientSpaceSeatID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<int?>("MemberBookingSpaceID");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<double?>("SeatPrice");

                    b.Property<string>("SeatStatus");

                    b.HasKey("MemberBookingSpaceSeatID");

                    b.ToTable("MemberBookingSpaceSeat");
                });

            modelBuilder.Entity("HiSpaceModels.MemberMaster", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientMembershipPlanID");

                    b.Property<string>("Country");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<float?>("DepositeNonRefundable");

                    b.Property<float?>("DepositeRefundable");

                    b.Property<string>("Description");

                    b.Property<float?>("DiscountPercent");

                    b.Property<float?>("DiscountedPrice");

                    b.Property<string>("Doc_ContactPersonAadhaar");

                    b.Property<string>("Doc_ContactPersonPAN");

                    b.Property<string>("Doc_RCCopy");

                    b.Property<string>("Email");

                    b.Property<int?>("Fax");

                    b.Property<string>("GSTIN");

                    b.Property<string>("MemberName");

                    b.Property<string>("MemberPassword");

                    b.Property<bool>("MemberStatus");

                    b.Property<string>("MemberUsername");

                    b.Property<DateTime?>("MembershipExpiryDate");

                    b.Property<double?>("MembershipPriceOnDate");

                    b.Property<DateTime?>("MembershipStartedDate");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<string>("Number");

                    b.Property<string>("PAN");

                    b.Property<int?>("Pincode");

                    b.Property<string>("PrimaryContactEmail");

                    b.Property<string>("PrimaryContactName");

                    b.Property<string>("PrimaryContactNumber");

                    b.Property<DateTime?>("RenewalAlertDate");

                    b.Property<int?>("RenewalAlertDays");

                    b.Property<string>("State");

                    b.Property<string>("UAN");

                    b.HasKey("MemberID");

                    b.ToTable("MemberMaster");
                });

            modelBuilder.Entity("HiSpaceModels.MembershipHistory", b =>
                {
                    b.Property<int>("MembershipHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientMembershipPlanID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime?>("ExpiredDate");

                    b.Property<int?>("MemberID");

                    b.Property<double?>("PriceOnDate");

                    b.Property<DateTime?>("RenewalDate");

                    b.Property<DateTime?>("StartedDate");

                    b.HasKey("MembershipHistoryID");

                    b.ToTable("MembershipHistory");
                });

            modelBuilder.Entity("HiSpaceModels.MyCard", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientSpaceFloorPlanID");

                    b.Property<int?>("ClientSpaceSeatID");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsFullSpace");

                    b.Property<int?>("MemberID");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<int?>("NumberOfSeats");

                    b.Property<double?>("Price");

                    b.Property<string>("SpaceName");

                    b.HasKey("CardID");

                    b.ToTable("MyCard");
                });

            modelBuilder.Entity("HiSpaceModels.ScaleMetric", b =>
                {
                    b.Property<int>("ScaleMetricID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ScaleMetricName");

                    b.HasKey("ScaleMetricID");

                    b.ToTable("ScaleMetric");
                });

            modelBuilder.Entity("HiSpaceModels.UserLogin", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("ClientID");

                    b.Property<int?>("ClientLocationID");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDateTime");

                    b.Property<DateTime?>("LastLoginDateTime");

                    b.Property<long?>("LoginCount");

                    b.Property<int?>("MemberID");

                    b.Property<int?>("ModifyBy");

                    b.Property<DateTime?>("ModifyDateTime");

                    b.Property<string>("Password");

                    b.Property<int>("UserType");

                    b.Property<string>("Username");

                    b.HasKey("UserID");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("HiSpaceModels.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserTypeName");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("HiSpaceModels.WSpaceType", b =>
                {
                    b.Property<int>("WSpaceTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilePath");

                    b.Property<string>("WSpaceTypeName");

                    b.HasKey("WSpaceTypeID");

                    b.ToTable("WSpaceType");
                });
#pragma warning restore 612, 618
        }
    }
}
