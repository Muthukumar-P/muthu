using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("FacilityMaster")]
    public class FacilityMaster
    {
        [Key]
        public int FacilityID { set; get; }

        public string FacilityName { set; get; }

        public string CategoryName { set; get; }
    }
}
