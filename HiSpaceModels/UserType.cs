using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("UserType")]
    public class UserType
    {
        [Key]
        public int UserTypeID { set; get; }

        public string UserTypeName { set; get; }        
    }
}
