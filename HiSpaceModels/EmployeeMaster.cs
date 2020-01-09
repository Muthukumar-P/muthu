using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("EmployeeMaster")]
    public class EmployeeMaster
    {
        [Key]
        public int EmpID { set; get; }

        public int MemberID { set; get; }
        public string EmpCode { set; get; }
        public string Name { set; get; }
        public string Designation { set; get; }
        public string PAN { set; get; }
        public string Identification { set; get; }
        public DateTime? DOJ { set; get; }
        public DateTime? DOR { set; get; }
        public int? CreatedBy { set; get; }
        public DateTime? CreatedDateTime { set; get; }
        public int? ModifyBy { set; get; }
        public DateTime? ModifiedDateTime { set; get; }
    }
}
