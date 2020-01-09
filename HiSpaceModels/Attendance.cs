using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiSpaceModels
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        public int AttendanceID { set; get; }

        public int? MemberID { set; get; }

        public string EmpCode { set; get; }

        public DateTime? AttendanceDate { set; get; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:tt}", ApplyFormatInEditMode = true)]
        public TimeSpan? InTime { set; get; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:tt}", ApplyFormatInEditMode = true)]
        public TimeSpan? OutTime { set; get; }

        public int? CreatedBy { set; get; }

        public DateTime? CreatedDateTime { set; get; }

    }
}
