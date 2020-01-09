using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("ClientSpaceAvailableTime")]
    public class ClientSpaceAvailableTime
    {
        [Key]
        public int ClientSpaceAvailableTimeID { set; get; }

        public int? ClientID { set; get; }

        public int? ClientFloorID { set; get; }

        public int? ClientSpaceFloorPlanID { set; get; }

        public bool Is24Hours { set; get; }

        public bool MonToFriDay { set; get; }

        public string StartHours { set; get; }

        public string EndHours { set; get; }

        public int? CreatedBy { set; get; }

        public DateTime CreatedDateTime { set; get; }

        public int? ModifyBy { set; get; }

        public DateTime? ModifyDateTime { set; get; }
    }
}
