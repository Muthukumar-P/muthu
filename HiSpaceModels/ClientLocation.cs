using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HiSpaceModels
{
    [Table("ClientLocation")]
    public class ClientLocation
    {
        [Key]
        public int ClientLocationID { set; get; }

        public int ClientID { set; get; }

		[DisplayName("Client Location")]
        public string ClientLocationName { set; get; }

		[DisplayName("No. of Seats")]
        public int? NumberOfSeats { set; get; }

		[DisplayName("Status")]
        public bool ClientLocationStatus { set; get; }

		[DisplayName("Address")]
        public string Address { set; get; }

		[DisplayName("City")]
        public string City { set; get; }

		[DisplayName("State")]
        public string State { set; get; }

		[DisplayName("Country")]
        public string Country { set; get; }

		[DisplayName("Email")]
        public string Email { set; get; }

		[DisplayName("Fax")]
        public int? Fax { set; get; }

		[DisplayName("Pincode")]
        public int? Pincode { set; get; }

		[DisplayName("Contact Name")]
        public string ContactPersonName { set; get; }

		[DisplayName("Contact Aadhaar")]
        public string ContactPersonAadhaar { set; get; }

		[DisplayName("Contact PAN")]
        public string ContactPersonPAN { set; get; }

        public int? CreatedBy { set; get; }
        public DateTime? CreatedDateTime { set; get; }
        public int? ModifyBy { set; get; }
        public DateTime? ModifyDateTime { set; get; }
    }
}
