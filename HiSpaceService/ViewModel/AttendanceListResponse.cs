using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class AttendanceListResponse
    {
        public int AttendanceID { set; get; }

        public int? MemberID { set; get; }

        public int? EmpID { set; get; }

        public DateTime? AttendanceDate { set; get; }

        public TimeSpan? InTime { set; get; }

        public TimeSpan? OutTime { set; get; }

        public string EmpCode { set; get; }

        public string Name { set; get; }

        public string Designation { set; get; }
    }
}
