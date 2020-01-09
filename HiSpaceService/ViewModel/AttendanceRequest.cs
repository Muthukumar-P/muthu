using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class AttendanceRequest
    {
        public int MemberID { set; get; }
        public int? EmpID { set; get; }
        public DateTime? FromDate { set; get; }
        public DateTime? ToDate { set; get; }        
    }
}
