using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HiSpaceService.Models;
using HiSpaceModels;

namespace HiSpaceService.Models
{
    public class HiSpaceContext : DbContext
    {
        public HiSpaceContext(DbContextOptions<HiSpaceContext> options)
           : base(options)
        {
        }

        public DbSet<ChairType> ChairTypes { get; set; }
        public DbSet<ClientLocation> ClientLocations { get; set; }
        public DbSet<ClientMaster> ClientMasters { get; set; }
        public DbSet<ClientFacility> ClientFacilities { get; set; }
        public DbSet<ClientWorkSpaceFloorPlan> ClientWorkSpaceFloorPlans { get; set; }
        public DbSet<ClientSpaceSeat> ClientSpaceSeats { get; set; }
        public DbSet<FacilityMaster> FacilityMasters { get; set; }
        public DbSet<MemberMaster> Members { get; set; }
        public DbSet<MembershipHistory> MembershipHistories { get; set; }
        public DbSet<ClientMembershipPlan> ClientMembershipPlans { get; set; }
        public DbSet<ClientMembershipPlanHistory> ClientMembershipPlanHistories { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<WSpaceType> WSpaceTypeNames { get; set; }
        public DbSet<ScaleMetric> ScaleMetrics { get; set; }
        public DbSet<MemberBookingSpace> MemberBookingSpaces { get; set; }
        public DbSet<MemberBookingSpaceSeat> MemberBookingSpaceSeats { get; set; }
        public DbSet<ClientFloor> ClientFloors { get; set; }
        public DbSet<ClientSpaceAvailableTime> ClientSpaceAvailableTimes { get; set; }
        public DbSet<MyCard> MyCards { get; set; }
        public DbSet<EmployeeMaster> Employees { get; set; }
        public DbSet<HolidayMaster> Holidays { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

    }
}
