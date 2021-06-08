using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{	
	[Table("FacilityBooking")]
    public class FacilityBooking
	{
		[Key]
		public int FacilityBookingID { set; get; }
		
		public int? MemberBookingSpaceID { set; get; }

		public MemberBookingSpace SpaceBooking { get; set; }

		public int? ClientFacilityID { set; get; }

		public ClientFacility ClientFacility { get; set; }

		public double Quantity { get; set; }
		
		public double DiscountPercent { get; set; }

		public bool IsIncludeInInvoice { get; set; }
				
		public int? CreatedBy { set; get; }
		
		public DateTime? CreatedDateTime { set; get; }
		
		public int? ModifyBy { set; get; }
		
		public DateTime? ModifyDateTime { set; get; }		
	}
}