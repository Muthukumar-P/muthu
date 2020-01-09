using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class MembershipPlanHistoryResponse
    {
        public MembershipPlanHistoryResponse()
        {            
        }
        public int MembershipHistoryID { set; get; }
        public string MembershipName { set; get; }
        public int? MembershipDuration { set; get; }
        public string MembershipDurationType { set; get; }
        public double? Price { set; get; }
        public string Description { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? StartedDate { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? ExpiredDate { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? RenewalDate { set; get; }
        public double? PriceOnDate { set; get; }
    }
}
