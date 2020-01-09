using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HiSpaceModels
{
    [Table("MemberMaster")]
    public class MemberMaster
    {
        [Key]
        public int MemberID { set; get; }
        
        [DisplayName("Member Name")]
        public string MemberName { set; get; }

        [DisplayName("Adress")]
        public string Address { set; get; }

        [DisplayName("City")]
        public string City { set; get; }

        [DisplayName("State")]
        public string State { set; get; }        

        [DisplayName("Email")]
        public string Email { set; get; }
                
        public int? ClientMembershipPlanID { set; get; }

        [DisplayName("Membership Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? MembershipStartedDate { set; get; }

        [DisplayName("Membership Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? MembershipExpiryDate { set; get; }

        [DisplayName("Renewal Alert Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? RenewalAlertDate { set; get; }

        [DisplayName("Membership Price On Date")]
        public double? MembershipPriceOnDate { set; get; }

        public int? RenewalAlertDays { set; get; }

        public int? CreatedBy { set; get; }
        public DateTime? CreatedDateTime { set; get; }
        public int? ModifyBy { set; get; }
        public DateTime? ModifyDateTime { set; get; }

        [DisplayName("Client ID")]
        public int? ClientID { set; get; }

        [DisplayName("GSTIN")]
        public string GSTIN { set; get; }

        [DisplayName("PAN")]
        public string PAN { set; get; }

        [DisplayName("UAN")]
        public string UAN { set; get; }

        [DisplayName("Fax")]
        public int? Fax { set; get; }

        [DisplayName("Description")]
        public string Description { set; get; }

        


        [DisplayName("Country")]
        public string Country { set; get; }

        [DisplayName("Pincode")]
        public int? Pincode { set; get; }


        [DisplayName("Deposite Refundable Amount")]
        public float? DepositeRefundable { set; get; }

        [DisplayName("Deposite NonRefundable Amount")]
        public float? DepositeNonRefundable { set; get; }

        [DisplayName("Discount (%)")]
        public float? DiscountPercent { set; get; }

        [DisplayName("Final Cost")]
        public float? DiscountedPrice { set; get; }

        [DisplayName("Status")]
        public bool MemberStatus { set; get; }

        [DisplayName("Primary Contact Aadhaar")]
        public string Doc_ContactPersonAadhaar { set; get; }

        [DisplayName("Primary Contact PAN")]
        public string Doc_ContactPersonPAN { set; get; }

        [DisplayName("Membership RCCopy")]
        public string Doc_RCCopy { set; get; }

        [DisplayName("Contact Person Name")]
        public string PrimaryContactName { set; get; }

        [DisplayName("Person Number")]
        public string PrimaryContactNumber { set; get; }

        [DisplayName("Person Email")]
        public string PrimaryContactEmail { set; get; }

        [DisplayName("Member Username")]
        public string MemberUsername { set; get; }

        [DisplayName("Member Password")]
        public string MemberPassword { set; get; }

        [DisplayName("Member Phone")]
        public string Number { set; get; }

    }
}
