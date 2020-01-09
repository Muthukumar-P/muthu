using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class SpaceDetailsListSearchResponse
    {
        public SpaceDetailsListSearchResponse()
        {
            space = new ClientWorkSpaceFloorPlan();
            client = new ClientMaster();
            location = new ClientLocation();
            //facilities = new List<FacilityMaster>();
        }
        public ClientWorkSpaceFloorPlan space { set; get; }
        public ClientMaster client { set; get; }
        public ClientLocation location { set; get; }
        //public List<FacilityMaster> facilities { set; get; }
        public int AvailableSeats { set; get; }
        public int OccupiedSeats { set; get; }
        public int AvailableFacilities { set; get; }

    }
}
