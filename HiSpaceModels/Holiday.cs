using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("HolidayMaster")]
    public class HolidayMaster
    {
        [Key]
        public int HolidayID { set; get; }

        public int ClientID { set; get; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime HolidayDate { set; get; }

        public string HolidayDetails { set; get; }

    }
}
