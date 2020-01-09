using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HiSpaceModels
{
    [Table("MemberBookingSpace")]
    public class MemberBookingSpace
    {
        [Key]
        public int MemberBookingSpaceID { set; get; }
        public int? MemberID { set; get; }
        public int? ClientID { set; get; }
        public int? ClientLocationID { set; get; }
        public int? ClientSpaceFloorPlanID { set; get; }
        public double? SpacePrice { set; get; }
        public string BookingStatus { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDateTime { set; get; }
        public int? ModifyBy { set; get; }
        public DateTime? ModifyDateTime { set; get; }
    }
}
