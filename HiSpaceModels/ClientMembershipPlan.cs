using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("ClientMembershipPlan")]
    public class ClientMembershipPlan
    {
        [Key]
        public int ClientMembershipPlanID { set; get; }

        public int? ClientID { set; get; }
        public string MembershipName { set; get; }
        public int? MembershipDuration { set; get; }
        public string MembershipDurationType { set; get; }
        public double? Price { set; get; }
        public int? RenewalAlertDays { set; get; }
        public bool? IsActive { set; get; }
        public bool? IsRecommented { set; get; }
        public string Description { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDateTime { set; get; }
        public int? ModifyBy { set; get; }
        public DateTime? ModifyDateTime { set; get; }

    }
}
