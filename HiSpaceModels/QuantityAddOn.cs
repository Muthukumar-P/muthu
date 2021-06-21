using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{	
	[Table("QuantityAddOn")]
    public class QuantityAddOn
	{
		[Key]
		public int QuantityAddOnID { set; get; }
		
		public int? MemberBookingSpaceID { set; get; }

		public string AddOnName { set; get; }

		public double ActualCost { get; set; }

		public double Quantity { get; set; }
		
		public double DiscountPercent { get; set; }

        public double ReducedCost { get; set; }

		public bool IsIncludeInInvoice { get; set; }
				
		public int? CreatedBy { set; get; }
		
		public DateTime? CreatedDateTime { set; get; }
		
		public int? ModifyBy { set; get; }
		
		public DateTime? ModifyDateTime { set; get; }
		
		public bool IsActive { get; set; } = true;
	}
}