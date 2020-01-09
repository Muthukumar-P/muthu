using HiSpaceModels;
using HiSpaceService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.ViewModel
{
    public class WorkSpaceDetailsResponse
    {
        public WorkSpaceDetailsResponse()
        {
            selectedSpace = new ClientWorkSpaceFloorPlan();
            client = new ClientMaster();
            location = new ClientLocation();
            clientFloors = new List<ClientFloorDetails>();
        }
        public ClientWorkSpaceFloorPlan selectedSpace { set; get; }
        public ClientMaster client { set; get; }
        public ClientLocation location { set; get; }
        public List<ClientFloorDetails> clientFloors { set; get; }
    }
}
