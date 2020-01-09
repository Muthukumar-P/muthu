using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HiSpaceModels
{
	[Table("ClientMaster")]
	public class ClientMaster
	{
		[Key]
		public int ClientID { set; get; }

		[DisplayName("Client Name")]
		public string ClientName { set; get; }

		[DisplayName("Client Status")]
		public string ClientStatus { set; get; }

        [DisplayName("Active")]
        public bool Active { set; get; }

        [DisplayName("GSTIN")]
		public string GSTIN { set; get; }

		[DisplayName("PAN")]
		public string PAN { set; get; }

		[DisplayName("UAN")]
		public string UAN { set; get; }

		[DisplayName("Address")]
		public string Address { set; get; }

		[DisplayName("City")]
		public string City { set; get; }

		[DisplayName("State")]
		public string State { set; get; }

		[DisplayName("Country")]
		public string Country { set; get; }

		[DisplayName("Client Email")]
		public string Email { set; get; }

		[DisplayName("Fax")]
		public int? Fax { set; get; }

		[DisplayName("Pincode")]
		public int? Pincode { set; get; }

		[DisplayName("Logo")]
		public string ClientLogo { set; get; }

		[DisplayName("RCCopy")]
		public string Doc_RCCopy { set; get; }

		[DisplayName("PANCopy")]
		public string Doc_PANCopy { set; get; }

		[DisplayName("GSTCopy")]
		public string Doc_GSTCopy { set; get; }

		[DisplayName("AgreementCopy")]
		public string Doc_MembershipAgreementCopy { set; get; }

		[DisplayName("Contact Aadhaar")]
		public string Doc_ContactPersonAadhaar { set; get; }

		[DisplayName("Contact PAN")]
		public string Doc_ContactPersonPAN { set; get; }

		public int? CreatedBy { set; get; }

		public DateTime? CreatedDateTime { set; get; }

		public int? ModifyBy { set; get; }

		public DateTime? ModifyDateTime { set; get; }

		[DisplayName("Client Number")]
		public string ClientNumber { set; get; }

		[DisplayName("Description")]
		public string Description { set; get; }

		[DisplayName("Contact Name")]
		public string PrimaryContactName { set; get; }

		[DisplayName("Contact Number")]
		public string PrimaryContactNumber { set; get; }

		[DisplayName("Contact Email")]
		public string PrimaryContactEmail { set; get; }

		[DisplayName("Client Username")]
		public string ClientUsername { set; get; }

		[DisplayName("Client Password")]
		public string ClientPassword { set; get; }
	}
}
