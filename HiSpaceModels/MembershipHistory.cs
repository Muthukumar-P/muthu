using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("MembershipHistory")]
    public class MembershipHistory
    {
        [Key]
        public int MembershipHistoryID { set; get; }
        public int? ClientMembershipPlanID { set; get; }
        public int? MemberID { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? StartedDate { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? ExpiredDate { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? RenewalDate { set; get; }
        public double? PriceOnDate { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime CreatedDateTime { set; get; }

    }
}
