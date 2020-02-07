using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HiSpaceModels
{
	[Table("Lead")]
	public class Lead
	{
		[Key]
		public int LeadID { set; get; }

		[DisplayName("Client ID")]
		public int ClientID { set; get; }

		[DisplayName("Lead Code")]
		public string LeadGenerationCode { set; get; }

		[DisplayName("Name")]
		public string LeadName { set; get; }

		[DisplayName("Phone")]
		public string Phone { set; get; }

		[DisplayName("Email")]
		public string Email { set; get; }

		[DisplayName("Address")]
		public string Address { set; get; }

		[DisplayName("City")]
		public string City { set; get; }

		[DisplayName("State")]
		public string State { set; get; }

		[DisplayName("Country")]
		public string Country { set; get; }

		[DisplayName("Pincode")]
		public int? Pincode { set; get; }

		[DisplayName("Aadhaar No.")]
		public string Aadhaar { set; get; }

		[DisplayName("Space Type")]
		public string SpaceType { set; get; }

		[DisplayName("Total Employee")]
		public int? TotalEmployee { set; get; }

		[DisplayName("Total Seat")]
		public int? TotalSeat { set; get; }

		[DisplayName("Description")]
		public string Description { set; get; }

		public int? CreatedBy { set; get; }

		public DateTime? CreatedDateTime { set; get; }

		public int? ModifyBy { set; get; }

		public DateTime? ModifyDateTime { set; get; }
	}
}