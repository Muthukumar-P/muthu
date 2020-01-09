using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class MemberBookingRequest
    {
        public List<MemberBookingSpace> memberBookingSpaces { set; get; }
        public List<MemberBookingSpaceSeat> memberBookingSpaceSeats { set; get; }       
    }
}
