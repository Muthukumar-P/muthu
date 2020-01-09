using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HiSpaceModels
{
    [Table("MemberBookingSpaceSeat")]
    public class MemberBookingSpaceSeat
    {
        [Key]
        public int MemberBookingSpaceSeatID { set; get; }
        public int? MemberBookingSpaceID { set; get; }
        public int? ClientSpaceSeatID { set; get; }
        public double? SeatPrice { set; get; }
        public string SeatStatus { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDateTime { set; get; }
        public int? ModifyBy { set; get; }
        public DateTime? ModifyDateTime { set; get; }
    }
}
