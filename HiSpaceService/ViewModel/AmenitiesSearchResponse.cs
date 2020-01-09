using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class AmenitiesSearchResponse
    {
        public int FacilityID { set; get; }
        public string FacilityName { set; get; }
        public string CategoryName { set; get; }
        public double FacilityInUseCount { set; get; }
        public bool IsSelected { set; get; }

    }
}
