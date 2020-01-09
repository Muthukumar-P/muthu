
using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.Models
{
    public class ClientFloorSpaceDetails
    {
        public ClientFloorSpaceDetails()
        {
            clientFloorSpace = new ClientWorkSpaceFloorPlan();
            clientFloorSpaceSeats = new List<ClientSpaceSeat>();            
        }

        public ClientWorkSpaceFloorPlan clientFloorSpace { set; get; }
        public List<ClientSpaceSeat> clientFloorSpaceSeats { set; get; }
        public int clientFloorSpaceSeatsCount = 0;
    }
}
