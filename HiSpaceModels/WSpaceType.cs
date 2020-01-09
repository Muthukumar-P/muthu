using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("WSpaceType")]
    public class WSpaceType
    {
        [Key]
        public int WSpaceTypeID { set; get; }

        public string WSpaceTypeName { set; get; }

        public string FilePath { set; get; }


    }
}
