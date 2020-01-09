using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class SpaceBookingResponse
    {
        public int ClientSpaceFloorPlanID { set; get; }
        public int? ClientID { set; get; }
        public int? ClientLocationID { set; get; }
        public string ClientName { set; get; }
        public string ClientLocationName { set; get; }
        public string SpaceName { set; get; }
        public string Status { set; get; }
        public int? WSpaceTypeID { set; get; }
        public string WSpaceTypeName { set; get; }
        public int? ChairTypeID { set; get; }
        public string ChairTypeName { set; get; }
        public int? Floor { set; get; }
        public int? NumberOfSeats { set; get; }
        public double? Price { set; get; }
        public int? ScaleMetricID { set; get; }
        public string ScaleMetricName { set; get; }
        public double? FloorLength { set; get; }
        public double? FloorBreadth { set; get; }
        public int? NumberOfRows { set; get; }
        public int? NumberOfColumns { set; get; }
        public double? SeatSize { set; get; }
        public string FloorPlanFilePath { set; get; }
        public string ContactPersonName { set; get; }
        public string Verification { set; get; }
    }
}
