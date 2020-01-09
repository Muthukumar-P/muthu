using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("ChairType")]
    public class ChairType
    {
        [Key]
        public int ChairTypeID { set; get; }

        public string ChairTypeName { set; get; }
    }
}
