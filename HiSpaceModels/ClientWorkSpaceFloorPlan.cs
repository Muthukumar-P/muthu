using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HiSpaceModels
{
	//[Serializable]
	[Table("ClientWorkSpaceFloorPlan")]
	public class ClientWorkSpaceFloorPlan
	{
		[Key]
		public int ClientSpaceFloorPlanID { set; get; }

		public int? ClientID { set; get; }

		public int? ClientLocationID { set; get; }

		[DisplayName("Space Name")]
		public string SpaceName { set; get; }

		[DisplayName("WorkSpace Type")]
		public int? WSpaceTypeID { set; get; }

		[DisplayName("Chair Type")]
		public int? ChairTypeID { set; get; }

		public int? ClientFloorID { set; get; }

		[DisplayName("No. of Seats")]
		public int? NumberOfSeats { set; get; }

		[DisplayName("Price")]
		public double? Price { set; get; }

		[DisplayName("Status")]
		public string Status { set; get; }

		public int? OccupiedBy { set; get; }

		public int? TotalViews { set; get; }

		public bool IsEnable { set; get; }

		public string FloorPlanFilePath { set; get; }

		[DisplayName("Scale Metric")]
		public int? ScaleMetricID { set; get; }

		[DisplayName("Floor Length")]
		public double? FloorLength { set; get; }

		[DisplayName("Floor Breadth")]
		public double? FloorBreadth { set; get; }

		[DisplayName("No. of Rows")]
		public int? NumberOfRows { set; get; }

		[DisplayName("No. of Columns")]
		public int? NumberOfColumns { set; get; }

		[DisplayName("Seat Size")]
		public double? SeatSize { set; get; }
		public int? CreatedBy { set; get; }
		public DateTime? CreatedDateTime { set; get; }
		public int? ModifyBy { set; get; }
		public DateTime? ModifyDateTime { set; get; }

		[DisplayName("Verification")]
		public string Verification { set; get; }

		[DisplayName("Description")]
		public string SpaceDescription { set; get; }

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
