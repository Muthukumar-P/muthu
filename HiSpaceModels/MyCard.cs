using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("MyCard")]
    public class MyCard
    {
        [Key]
        public int CardID { set; get; }

        public int? ClientID { set; get; }

        public int? MemberID { set; get; }

        public int? ClientSpaceFloorPlanID { set; get; }

        public string SpaceName { set; get; }

        public int? NumberOfSeats { set; get; }

        public double? Price { set; get; }

        public int? ClientSpaceSeatID { set; get; }

        public bool? IsFullSpace { set; get; }

        public string Description { set; get; }

        public DateTime? CreatedDateTime { set; get; }

        public DateTime? ModifyDateTime { set; get; }


    }
}
