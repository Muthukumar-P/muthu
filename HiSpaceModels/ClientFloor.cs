using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HiSpaceModels
{
    [Table("ClientFloor")]
    public class ClientFloor
    {
        [Key]
        public int ClientFloorID { set; get; }

        public int? ClientID { set; get; }

        public int? ClientLocationID { set; get; }

        [DisplayName("Floor Number")]
        public int? FloorNumber { set; get; }

        [DisplayName("Floor Name")]
        public string FloorName { set; get; }

        [DisplayName("Floor Image")]
        public string FloorPlanFilePath { set; get; }

        [DisplayName("Paid Amenities Price")]
        public double? PaidAmenitiesPrice { set; get; }

        [DisplayName("Floor Description")]
        public string FloorDescription { set; get; }

        public int? CreatedBy { set; get; }

        public DateTime? CreatedDateTime { set; get; }

        [DisplayName("Status")]
        public bool Active { set; get; }
    }
}
