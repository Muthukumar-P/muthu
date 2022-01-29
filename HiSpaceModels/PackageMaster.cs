using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HiSpaceModels
{
    [Table("PackageMaster")]
    public class PackageMaster
    {
        [Key]
        public int ID { set; get; }

        public string PackageName { get; set; }

        public SeatReductionValue SeatReductionValue { set; get; } 

        public SeatReductionPercent SeatReductionPercent { set; get; } 

        public SeatReductionTotal SeatReductionTotal { set; get; } 

        public SeatFreebie SeatFreebie { get; set; }  

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { set; get; }

        public int? ModifyBy { set; get; }

        public DateTime? ModifyDateTime { set; get; }

        public bool IsActive { get; set; } = true;
    }
}
