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
		public bool? Is24 { set; get; }

		public bool? SunAvail { set; get; }
		public TimeSpan? SunOpen { set; get; }
		public TimeSpan? SunClose { set; get; }

		public bool? MonAvail { set; get; }
		public TimeSpan? MonOpen { set; get; }
		public TimeSpan? MonClose { set; get; }

		public bool? TueAvail { set; get; }
		public TimeSpan? TueOpen { set; get; }
		public TimeSpan? TueClose { set; get; }

		public bool? WedAvail { set; get; }
		public TimeSpan? WedOpen { set; get; }
		public TimeSpan? WedClose { set; get; }

		public bool? ThuAvail { set; get; }
		public TimeSpan? ThuOpen { set; get; }
		public TimeSpan? ThuClose { set; get; }

		public bool? FriAvail { set; get; }
		public TimeSpan? FriOpen { set; get; }
		public TimeSpan? FriClose { set; get; }

		public bool? SatAvail { set; get; }
		public TimeSpan? SatOpen { set; get; }
		public TimeSpan? SatClose { set; get; }
	}
}
