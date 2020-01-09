using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("ClientSpaceSeat")]
    public class ClientSpaceSeat
    {
        [Key]
        public int ClientSpaceSeatID { set; get; }

        public int ClientSpaceFloorPlanID { set; get; }
        public int SeatXCoord { set; get; }
        public int SeatYCoord { set; get; }
        public string SeatDescription { set; get; }
        public double? SeatPrice { set; get; }
        public string SeatStatus { set; get; }
        public int? OccupiedBy { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDateTime { set; get; }
        public int? ModifyBy { set; get; }
        public DateTime? ModifyDateTime { set; get; }
        public int? MemberID { set; get; }
    }
}
