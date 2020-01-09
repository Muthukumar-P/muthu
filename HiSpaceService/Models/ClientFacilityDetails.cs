
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.Models
{
    public class ClientFacilityDetails
    {
        public int FacilityID { set; get; }
        public string FacilityName { set; get; }
        public string CategoryName { set; get; }
        public bool Available { set; get; }
        public bool IsPaidAmenity { set; get; }
    }
}
