using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class MemberBookingResponse
    {
        public int MemberBookingSpaceID { set; get; }
        public int ClientSpaceFloorPlanID { set; get; }
        public int MemberID { set; get; }
        public string MemberName { set; get; }
        public string ClientName { set; get; }
        public string ClientLocationName { set; get; }
        public string SpaceName { set; get; }
        public string BookingStatus { set; get; }        
        public string WSpaceTypeName { set; get; }        
        public int? Floor { set; get; }
        public int? NumberOfSeats { set; get; }
        public double? SpacePrice { set; get; }        
    }
}
