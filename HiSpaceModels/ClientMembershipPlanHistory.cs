using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("ClientMembershipPlanHistory")]
    public class ClientMembershipPlanHistory
    {
        [Key]
        public int ClientMembershipPlanHistoryID { set; get; }

        public int? ClientMembershipPlanID { set; get; }
        public int? ClientID { set; get; }
        public string MembershipName { set; get; }
        public int? MembershipDuration { set; get; }
        public string MembershipDurationType { set; get; }        
        public double? Price { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDateTime { set; get; }

    }
}
